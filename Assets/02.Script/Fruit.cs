using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isDropped = false;

    FruitManager fruitManager;
    FruitController controller;

    void Start()
    {
        fruitManager = FindObjectOfType<FruitManager>();
        controller = FindObjectOfType<FruitController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // 과일이 벽 또는 다른 과일과 충돌했을 때
        if (other.transform.tag == "Wall" || other.transform.tag == "Fruit")
        {
            // 과일의 낙하가 완료됐을 때
            if (!isDropped)
            {
                isDropped = true;
                fruitManager.isDropped = true;

                controller.line.gameObject.SetActive(true);
                fruitManager.GetNextFruit();
                fruitManager.CreateFruit();
            }

            // 같은 과일끼리 충돌했을 때
            if (other.transform.name == this.name)
            {
                // 다른 과일과의 충돌 감지를 피하기 위해 콜라이더 비활성화
                if (GetComponent<PolygonCollider2D>()) GetComponent<PolygonCollider2D>().enabled = false;
                if (GetComponent<CircleCollider2D>()) GetComponent<CircleCollider2D>().enabled = false;

                Vector2 thisPos = this.transform.position;
                Vector2 otherPos = other.transform.position;

                // EvolutionFruit를 한 번만 호출하기 위한 조건문
                // 조건문이 없다면 충돌한 두 과일 모두 함수를 호출하게 됨
                if (thisPos.y < otherPos.y || (thisPos.y == otherPos.y && thisPos.x < otherPos.x))
                {
                    Vector2 collisionPoint = other.contacts[0].point;
                    int level = int.Parse(this.transform.name[6].ToString());

                    fruitManager.EvolutionFruit(collisionPoint, level);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 과일의 낙하가 완료됐고, GameOver 라인에 닿았을 때
        if (other.transform.tag == "GameOver" && isDropped)
        {
            GameManager.Instance.isGameOver = true;
            fruitManager.DeactivateComponent();
            StartCoroutine(GameManager.Instance.GameOver());
        }
    }

    public IEnumerator SetCollider()
    {
        // 한 번에 여러 번의 진화를 방지하기 위해 한 프레임 대기
        yield return new WaitForEndOfFrame();

        if (GetComponent<PolygonCollider2D>()) GetComponent<PolygonCollider2D>().enabled = true;
        if (GetComponent<CircleCollider2D>()) GetComponent<CircleCollider2D>().enabled = true;
    }
}

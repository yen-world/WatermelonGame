using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] GameObject respawnArea;
    [SerializeField] GameObject nextFruit;

    int randomNumber;
    int nextRandomNumber;
    public bool isDropped = true;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        randomNumber = Random.Range(0, 5);
        nextRandomNumber = Random.Range(0, 5);

        CreateFruit();
        ChangeNextFruit();
    }

    // 컨트롤러에 과일 생성
    public void CreateFruit()
    {
        Instantiate(GameManager.Instance.fruits[randomNumber], respawnArea.transform.position, GameManager.Instance.fruits[randomNumber].transform.rotation, respawnArea.transform);
    }

    // 과일 낙하
    public void DropFruit()
    {
        // 부모관계를 옮겨주고 리지드바디 활성화
        GameObject fruit = respawnArea.transform.GetChild(0).gameObject;
        fruit.transform.SetParent(transform.root);
        fruit.GetComponent<Rigidbody2D>().isKinematic = false;

        // 콜라이더 활성화
        if (fruit.GetComponent<PolygonCollider2D>()) fruit.GetComponent<PolygonCollider2D>().enabled = true;
        if (fruit.GetComponent<CircleCollider2D>()) fruit.GetComponent<CircleCollider2D>().enabled = true;
    }

    // 과일 진화
    public void EvolutionFruit(Vector2 collisionPoint, int level)
    {
        // 현재 과일의 단계만큼 스코어테이블에서 점수를 가져와서 점수 증가
        GameManager.Instance.currentScore += GameManager.Instance.ScoreTable[level];
        scoreManager.SetScore();

        // 진화할 과일이 수박이 아닐 때(수박은 사라져야함)
        if (level != 11)
        {
            // 충돌 위치에 상위 단계 과일 생성
            GameObject fruit = Instantiate(GameManager.Instance.fruits[level], collisionPoint, GameManager.Instance.fruits[randomNumber].transform.rotation);

            fruit.transform.SetParent(transform.root);
            fruit.GetComponent<Rigidbody2D>().isKinematic = false;
            fruit.GetComponent<Fruit>().isDropped = true;

            StartCoroutine(fruit.GetComponent<Fruit>().SetCollider());
        }
    }

    // 다음 과일 가져오기
    public void GetNextFruit()
    {
        randomNumber = nextRandomNumber;
        nextRandomNumber = Random.Range(0, 5);
        ChangeNextFruit();
    }

    // 다음 과일 이미지 변경
    public void ChangeNextFruit()
    {
        nextFruit.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.fruits[nextRandomNumber].GetComponent<SpriteRenderer>().sprite;
    }

    // 모든 과일들의 리지드바디, 콜라이더 비활성화
    public void DeactivateComponent()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            if (transform.GetChild(i).GetComponent<PolygonCollider2D>()) transform.GetChild(i).GetComponent<PolygonCollider2D>().enabled = false;
            if (transform.GetChild(i).GetComponent<CircleCollider2D>()) transform.GetChild(i).GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

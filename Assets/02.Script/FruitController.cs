using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    Vector2 vector;
    float speed = 5f;

    public GameObject line;

    FruitManager fruitManager;
    MainButton mainButtonScript;

    void Start()
    {
        fruitManager = FindObjectOfType<FruitManager>();
        mainButtonScript = FindObjectOfType<MainButton>();
    }

    void Update()
    {
        // 메뉴가 꺼져있는 상황이고, 게임이 종료되지 않았을 때
        if (!mainButtonScript.isActiveMenu && !GameManager.Instance.isGameOver)
        {
            // 좌우 방향키로 컨트롤러의 위치 조절
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.transform.position.x > -1.75f)
                {
                    vector.Set(-1, 0);
                    this.transform.Translate(vector * speed * Time.deltaTime);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (this.transform.position.x < 3.3f)
                {
                    vector.Set(1, 0);
                    this.transform.Translate(vector * speed * Time.deltaTime);
                }
            }
            // 이전 과일의 낙하가 완료되었고, 스페이스바를 눌렀을 때
            if (Input.GetKeyDown(KeyCode.Space) && fruitManager.isDropped)
            {
                line.gameObject.SetActive(false);
                fruitManager.isDropped = false;
                fruitManager.DropFruit();
            }
        }
    }
}

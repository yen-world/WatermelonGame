using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    int selectedButton;
    public bool isActiveMenu;

    [SerializeField] GameObject blackBackground;
    // 메인 씬의 버튼 오브젝트
    [SerializeField] GameObject[] mainButtons;
    // 버튼 활성화, 버튼 비활성화 이미지를 담은 스프라이트
    [SerializeField] SpriteRenderer[] mainButtonSprites;

    Animator animator;

    void Start()
    {
        selectedButton = 0;
        isActiveMenu = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ESC키를 눌러서 메뉴창 진입
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isGameOver)
        {
            if (!isActiveMenu)
            {
                isActiveMenu = true;
                blackBackground.gameObject.SetActive(true);
                animator.SetBool("Active", true);
                ChangeButtonSprite(mainButtons, mainButtonSprites, 0);
            }
        }

        // 상하 방향키 버튼으로 버튼 셀렉트
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButton--;
            if (selectedButton < 0) selectedButton = 2;
            ChangeButtonSprite(mainButtons, mainButtonSprites, selectedButton);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButton++;
            if (selectedButton > 2) selectedButton = 0;
            ChangeButtonSprite(mainButtons, mainButtonSprites, selectedButton);
        }

        // 메뉴창이 열려있을 때 스페이스바를 눌러서 해당 버튼 실행
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isActiveMenu)
            {
                // 게임에 돌아가기
                if (selectedButton == 0)
                {
                    isActiveMenu = false;
                    blackBackground.gameObject.SetActive(false);
                    animator.SetBool("Active", false);
                }
                // 재도전
                if (selectedButton == 1)
                {
                    isActiveMenu = false;
                    GameManager.Instance.currentScore = 0;
                    SceneManager.LoadScene("MainScene");
                }
                // 타이틀 화면으로
                if (selectedButton == 2)
                {
                    isActiveMenu = false;
                    GameManager.Instance.currentScore = 0;
                    SceneManager.LoadScene("TitleScene");
                }
            }
        }
    }

    // 선택된 버튼의 스프라이트를 바꿔주는 함수
    void ChangeButtonSprite(GameObject[] _buttons, SpriteRenderer[] _sprites, int _targetNum)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<SpriteRenderer>().sprite = _sprites[i * 2].sprite;
        }
        _buttons[_targetNum].GetComponent<SpriteRenderer>().sprite = _sprites[_targetNum * 2 + 1].sprite;
    }
}

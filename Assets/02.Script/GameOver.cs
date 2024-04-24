using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameOver : MonoBehaviour
{
    int selectedButton;

    [SerializeField] GameObject blackBackground;
    // 메인 씬의 버튼 오브젝트
    [SerializeField] GameObject[] gameOverButtons;
    // 버튼 활성화, 버튼 비활성화 이미지를 담은 스프라이트
    [SerializeField] Sprite[] gameOverButtonSprites;

    // Start is called before the first frame update
    void Start()
    {
        selectedButton = 0;
        blackBackground.SetActive(true);
        ChangeButtonSprite(gameOverButtons, gameOverButtonSprites, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우 방향키 버튼으로 버튼 셀렉트
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedButton--;
            if (selectedButton < 0) selectedButton = 1;
            ChangeButtonSprite(gameOverButtons, gameOverButtonSprites, selectedButton);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedButton++;
            if (selectedButton > 1) selectedButton = 0;
            ChangeButtonSprite(gameOverButtons, gameOverButtonSprites, selectedButton);
        }

        // 메뉴창이 열려있을 때 스페이스바를 눌러서 해당 버튼 실행
        if (Input.GetKeyDown(KeyCode.Space))
        {
            File.Delete("Assets/Resources/Result");

            // 재도전
            if (selectedButton == 0)
            {
                GameManager.Instance.currentScore = 0;
                SceneManager.LoadScene("MainScene");
                GameManager.Instance.isGameOver = false;
            }
            // 타이틀 화면으로
            if (selectedButton == 1)
            {
                SceneManager.LoadScene("TitleScene");
                GameManager.Instance.isGameOver = false;
            }

        }
    }

    // 선택된 버튼의 스프라이트를 바꿔주는 함수
    void ChangeButtonSprite(GameObject[] _buttons, Sprite[] _sprites, int _targetNum)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<SpriteRenderer>().sprite = _sprites[i * 2];
        }
        _buttons[_targetNum].GetComponent<SpriteRenderer>().sprite = _sprites[_targetNum * 2 + 1];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    // 현재 선택중인 버튼의 인덱스
    int selectedButton;

    // 타이틀 씬의 버튼 오브젝트
    [SerializeField] GameObject[] titleButtons;
    // 버튼 활성화, 버튼 비활성화 이미지를 담은 스프라이트
    [SerializeField] SpriteRenderer[] titleButtonSprites;

    // 메인 씬으로 이동하기 전 띄워주는 오브젝트
    [SerializeField] GameObject titleToGameBackground;

    // Start is called before the first frame update
    void Start()
    {
        selectedButton = 0;
        // 처음 시작했을 때는 첫 번재 버튼이 선택된 상태
        titleButtons[selectedButton].GetComponent<SpriteRenderer>().sprite = titleButtonSprites[1].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // 상하 방향키로 버튼 셀렉트
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButton--;
            if (selectedButton < 0) selectedButton = 1;
            ChangeButtonSprite(titleButtons, titleButtonSprites, selectedButton);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButton++;
            if (selectedButton > 1) selectedButton = 0;
            ChangeButtonSprite(titleButtons, titleButtonSprites, selectedButton);
        }
        // 스페이스바로 해당 버튼 클릭
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedButton == 0)
            {
                titleToGameBackground.gameObject.SetActive(true);
            }

            if (selectedButton == 1)
            {
                SceneManager.LoadScene("RuleScene");
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

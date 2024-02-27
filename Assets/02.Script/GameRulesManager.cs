using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRulesManager : MonoBehaviour
{
    // 현재 선택된 게임 방법 페이지 인덱스
    int selectedRule;
    // 게임 방법 페이지 오브젝트
    [SerializeField] GameObject[] Rules;

    // Start is called before the first frame update
    void Start()
    {
        selectedRule = 0;
        Rules[selectedRule].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우 방향키로 페이지 넘김
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedRule < 2) selectedRule++;
            ChangeRule(selectedRule);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedRule > 0) selectedRule--;
            ChangeRule(selectedRule);
        }
        // ESC키를 눌러서 타이틀 씬으로 전환
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    // 페이지 전환 시키는 함수
    void ChangeRule(int _selectedNum)
    {
        for (int i = 0; i < Rules.Length; i++)
        {
            Rules[i].gameObject.SetActive(false);
        }
        Rules[_selectedNum].gameObject.SetActive(true);
    }
}

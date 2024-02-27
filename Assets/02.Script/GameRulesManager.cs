using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRulesManager : MonoBehaviour
{
    int selectedRule;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    void ChangeRule(int _selectedNum)
    {
        for (int i = 0; i < Rules.Length; i++)
        {
            Rules[i].gameObject.SetActive(false);
        }
        Rules[_selectedNum].gameObject.SetActive(true);
    }
}

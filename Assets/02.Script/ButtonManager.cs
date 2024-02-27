using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    bool isTitleScene;
    int selectedButton;

    [SerializeField] GameObject[] titleButtons;
    [SerializeField] SpriteRenderer[] titleButtonSprites;

    [SerializeField] GameObject titleToGameBackground;

    // Start is called before the first frame update
    void Start()
    {
        isTitleScene = true;
        selectedButton = 0;
        titleButtons[selectedButton].GetComponent<SpriteRenderer>().sprite = titleButtonSprites[1].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTitleScene)
        {
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
    }

    void ChangeButtonSprite(GameObject[] _buttons, SpriteRenderer[] _sprites, int _targetNum)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<SpriteRenderer>().sprite = _sprites[i * 2].sprite;
        }
        _buttons[_targetNum].GetComponent<SpriteRenderer>().sprite = _sprites[_targetNum * 2 + 1].sprite;
    }
}

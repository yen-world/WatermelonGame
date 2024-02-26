using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    bool isTitleScene;
    int selectedButton;

    [SerializeField] GameObject[] titleButtons;
    [SerializeField] SpriteRenderer[] titleButtonSprites;

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
                print(selectedButton);
            }
        }
    }

    void ChangeButtonSprite(GameObject[] buttons, SpriteRenderer[] sprites, int targetNum)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<SpriteRenderer>().sprite = sprites[i * 2].sprite;
        }
        buttons[targetNum].GetComponent<SpriteRenderer>().sprite = sprites[targetNum * 2 + 1].sprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // ���� ��ġ�� ���� Ÿ��Ʋ ������ üũ
    bool isTitleScene;
    // ���� �������� ��ư�� �ε���
    int selectedButton;

    // Ÿ��Ʋ ���� ��ư ������Ʈ
    [SerializeField] GameObject[] titleButtons;
    // ��ư Ȱ��ȭ, ��ư ��Ȱ��ȭ �̹����� ���� ��������Ʈ
    [SerializeField] SpriteRenderer[] titleButtonSprites;

    // ���� ������ �̵��ϱ� �� ����ִ� ������Ʈ
    [SerializeField] GameObject titleToGameBackground;

    // Start is called before the first frame update
    void Start()
    {
        isTitleScene = true;
        selectedButton = 0;
        // ó�� �������� ���� ù ���� ��ư�� ���õ� ����
        titleButtons[selectedButton].GetComponent<SpriteRenderer>().sprite = titleButtonSprites[1].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� Ÿ��Ʋ ���̶��
        if (isTitleScene)
        {
            // ���� ����Ű�� ��ư ����Ʈ
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
            // �����̽��ٷ� �ش� ��ư Ŭ��
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

    // ���õ� ��ư�� ��������Ʈ�� �ٲ��ִ� �Լ�
    void ChangeButtonSprite(GameObject[] _buttons, SpriteRenderer[] _sprites, int _targetNum)
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<SpriteRenderer>().sprite = _sprites[i * 2].sprite;
        }
        _buttons[_targetNum].GetComponent<SpriteRenderer>().sprite = _sprites[_targetNum * 2 + 1].sprite;
    }
}

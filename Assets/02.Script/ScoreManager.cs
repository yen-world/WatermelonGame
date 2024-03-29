using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text currentScoreText;
    public TMP_Text highestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreText.text = GameManager.Instance.currentScore.ToString();
        highestScoreText.text = GameManager.Instance.highestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore()
    {
        if (GameManager.Instance.highestScore < GameManager.Instance.currentScore)
        {
            GameManager.Instance.highestScore = GameManager.Instance.currentScore;
        }

        currentScoreText.text = GameManager.Instance.currentScore.ToString();
        highestScoreText.text = GameManager.Instance.highestScore.ToString();
    }
}

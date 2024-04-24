using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text currentScoreText;
    public TMP_Text highestScoreText;

    void Start()
    {
        currentScoreText.text = GameManager.Instance.currentScore.ToString();
        highestScoreText.text = GameManager.Instance.highestScore.ToString();
    }

    // 스코어 갱신
    public void SetScore()
    {
        // 최고 점수보다 현재 점수가 높다면 최고 점수 갱신
        if (GameManager.Instance.highestScore < GameManager.Instance.currentScore)
        {
            GameManager.Instance.highestScore = GameManager.Instance.currentScore;
        }

        currentScoreText.text = GameManager.Instance.currentScore.ToString();
        highestScoreText.text = GameManager.Instance.highestScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public GameObject[] fruits;

    private int[] scoreTable = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66 };
    public int[] ScoreTable { get { return scoreTable; } }
    public int currentScore = 0;
    public int highestScore = 0;

    public bool isGameOver;
    public GameObject gameOverUI;
    public float gameOverWaitTime = 3f;
    public float gameOverCurrentTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject;
        gameObject.SetActive(true);
    }
}

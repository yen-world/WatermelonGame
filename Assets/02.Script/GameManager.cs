using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


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

    public IEnumerator GameOver()
    {
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject;
        GameObject screenShot = gameOverUI.transform.Find("ScreenShot").gameObject;

        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("Assets/Resources/Result.png");

        yield return new WaitForSeconds(1f);
        AssetDatabase.Refresh();

        screenShot.GetComponent<SpriteRenderer>().sprite = Resources.Load("Result", typeof(Sprite)) as Sprite;
        gameOverUI.SetActive(true);
    }
}

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

    // 게임오버 코루틴
    public IEnumerator GameOver()
    {
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject;
        GameObject screenShot = gameOverUI.transform.Find("ScreenShot").gameObject;

        // 안정적인 스크린샷을 위해 한 프레임 대기 이후 스크린샷 파일 생성
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("Assets/Resources/Result.png");

        // 1초 대기 후 에셋 새로고침
        yield return new WaitForSeconds(1f);
        AssetDatabase.Refresh();

        // 스크린샷 오브젝트의 스케일을 사용자 해상도에 대응하여 조절
        float width = 1920 / (float)Screen.width * screenShot.transform.localScale.x;
        float height = 1080 / (float)Screen.height * screenShot.transform.localScale.y;
        screenShot.transform.localScale = new Vector2(width, height);

        // 저장된 스크린샷 스프라이트를 오브젝트에 적용
        screenShot.GetComponent<SpriteRenderer>().sprite = Resources.Load("Result", typeof(Sprite)) as Sprite;
        gameOverUI.SetActive(true);
    }
}

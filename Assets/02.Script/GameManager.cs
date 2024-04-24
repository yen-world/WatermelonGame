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

        if (File.Exists("Assets/Result.png")) File.Delete("Assets/Result.png");
    }

    public IEnumerator GameOver()
    {
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject;
        GameObject screenshotUI = gameOverUI.transform.Find("ScreenShot").gameObject;

        // 안정적인 스크린샷을 위해 한 프레임 대기 이후 스크린샷 텍스쳐 생성
        yield return new WaitForEndOfFrame();
        Texture2D screenshot = ScreenCapture.CaptureScreenshotAsTexture();

        // 경로와 파일 이름을 지정하고 PNG 파일 생성
        string filePath = Path.Combine("Assets/", "Result.png");
        File.WriteAllBytes(filePath, screenshot.EncodeToPNG());

        // PNG 파일이 생성될 때까지 대기
        yield return new WaitUntil(() => File.Exists(filePath));

        // 저장된 PNG 파일을 텍스쳐로 불러옴
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(fileData);

        // 스크린샷 오브젝트의 스케일을 사용자 해상도에 대응하여 조절
        float width = 1920 / (float)Screen.width * screenshotUI.transform.localScale.x;
        float height = 1080 / (float)Screen.height * screenshotUI.transform.localScale.y;
        screenshotUI.transform.localScale = new Vector2(width, height);

        // 저장된 스크린샷 텍스쳐를 스프라이트로 변환해서 오브젝트에 적용
        screenshotUI.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        gameOverUI.SetActive(true);
    }
}

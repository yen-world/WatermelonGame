using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public bool isActiveMenu;
    public GameObject[] Fruits;

    private int[] scoreTable = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66 };
    public int[] ScoreTable { get { return scoreTable; } }
    public int currentScore;
    public int highestScore;

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

    // Start is called before the first frame update
    void Start()
    {
        isActiveMenu = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FruitManager : MonoBehaviour
{
    [SerializeField] GameObject respawnArea;
    [SerializeField] GameObject nextFruit;

    int randomNumber;
    int nextRandomNumber;
    public bool isDropped;

    ScoreManager theScore;

    // Start is called before the first frame update
    void Start()
    {
        theScore = FindObjectOfType<ScoreManager>();

        isDropped = true;
        randomNumber = Random.Range(0, 5);
        nextRandomNumber = Random.Range(0, 5);
        CreateFruit();
        ChangeNextFruit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateFruit()
    {
        Instantiate(GameManager.Instance.Fruits[randomNumber], respawnArea.transform.position, Quaternion.identity, respawnArea.transform);
    }

    public void DropFruit()
    {
        GameObject fruit = respawnArea.transform.GetChild(0).gameObject;
        fruit.transform.SetParent(transform.root);
        fruit.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void EvolutionFruit(Vector2 collisionPoint, int level)
    {
        GameManager.Instance.currentScore += GameManager.Instance.ScoreTable[level];
        theScore.SetScore();

        if (level != 11)
        {
            GameObject fruit = Instantiate(GameManager.Instance.Fruits[level], collisionPoint, Quaternion.identity);
            fruit.GetComponent<Rigidbody2D>().isKinematic = false;
            fruit.GetComponent<Fruit>().isDropped = true;
        }
    }

    public void GetNextFruit()
    {
        randomNumber = nextRandomNumber;
        nextRandomNumber = Random.Range(0, 5);
        ChangeNextFruit();
    }

    public void ChangeNextFruit()
    {
        nextFruit.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.Fruits[nextRandomNumber].GetComponent<SpriteRenderer>().sprite;
    }
}

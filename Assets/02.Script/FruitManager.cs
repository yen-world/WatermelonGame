using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        randomNumber = Random.Range(4, 5);
        nextRandomNumber = Random.Range(4, 5);
        CreateFruit();
        ChangeNextFruit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateFruit()
    {
        Instantiate(GameManager.Instance.fruits[randomNumber], respawnArea.transform.position, GameManager.Instance.fruits[randomNumber].transform.rotation, respawnArea.transform);
    }

    public void DropFruit()
    {
        GameObject fruit = respawnArea.transform.GetChild(0).gameObject;
        fruit.transform.SetParent(transform.root);
        fruit.GetComponent<Rigidbody2D>().isKinematic = false;

        if (fruit.GetComponent<PolygonCollider2D>()) fruit.GetComponent<PolygonCollider2D>().enabled = true;
        if (fruit.GetComponent<CircleCollider2D>()) fruit.GetComponent<CircleCollider2D>().enabled = true;
    }

    public void EvolutionFruit(Vector2 collisionPoint, int level)
    {
        GameManager.Instance.currentScore += GameManager.Instance.ScoreTable[level];
        theScore.SetScore();

        if (level != 11)
        {
            GameObject fruit = Instantiate(GameManager.Instance.fruits[level], collisionPoint, GameManager.Instance.fruits[randomNumber].transform.rotation);

            fruit.transform.SetParent(transform.root);
            fruit.GetComponent<Rigidbody2D>().isKinematic = false;
            fruit.GetComponent<Fruit>().isDropped = true;

            if (fruit.GetComponent<PolygonCollider2D>()) fruit.GetComponent<PolygonCollider2D>().enabled = true;
            if (fruit.GetComponent<CircleCollider2D>()) fruit.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void GetNextFruit()
    {
        randomNumber = nextRandomNumber;
        nextRandomNumber = Random.Range(4, 5);
        ChangeNextFruit();
    }

    public void ChangeNextFruit()
    {
        nextFruit.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.fruits[nextRandomNumber].GetComponent<SpriteRenderer>().sprite;
    }

    public void DeactivateComponent()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            if (transform.GetChild(i).GetComponent<PolygonCollider2D>()) transform.GetChild(i).GetComponent<PolygonCollider2D>().enabled = false;
            if (transform.GetChild(i).GetComponent<CircleCollider2D>()) transform.GetChild(i).GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

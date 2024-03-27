using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] GameObject respawnArea;

    int randomNumber;
    int nextRandomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 5);
        nextRandomNumber = Random.Range(0, 5);
        CreateFruit();
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
        GameObject fruit = Instantiate(GameManager.Instance.Fruits[level], collisionPoint, Quaternion.identity);
        fruit.GetComponent<Rigidbody2D>().isKinematic = false;
        fruit.GetComponent<Fruit>().isDropped = true;

        // switch (level)
        // {
        //     case 1:
        //     Instantiate
        //         break;
        //     case 2:
        //         break;
        //     case 3:
        //         break;
        //     case 4:
        //         break;
        //     case 5:
        //         break;
        //     case 6:
        //         break;
        //     case 7:
        //         break;
        //     case 8:
        //         break;
        //     case 9:
        //         break;
        //     case 10:
        //         break;
        //     case 11:
        //         break;
        // }
    }

    public void GetNextFruit()
    {
        randomNumber = nextRandomNumber;
        nextRandomNumber = Random.Range(0, 5);
    }
}

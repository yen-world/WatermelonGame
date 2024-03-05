using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    int randomNumber, nextRandomNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) CreateFruit();
    }

    void CreateFruit()
    {
        randomNumber = Random.Range(0, 5);
        Instantiate(GameManager.Instance.Fruits[randomNumber], GameManager.Instance.GuideLine.transform);
    }

    void DropFruit()
    {

    }
}

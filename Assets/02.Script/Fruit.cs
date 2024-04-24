using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isDropped = false;

    FruitManager fruitManager;
    FruitController controller;

    void Start()
    {
        fruitManager = FindObjectOfType<FruitManager>();
        controller = FindObjectOfType<FruitController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Wall" || other.transform.tag == "Fruit")
        {
            if (!isDropped)
            {
                controller.line.gameObject.SetActive(true);

                fruitManager.isDropped = true;
                isDropped = true;
                fruitManager.GetNextFruit();
                fruitManager.CreateFruit();
            }

            // if (other.transform.name == this.name)
            // {
            //     Vector2 thisPos = this.transform.position;
            //     Vector2 otherPos = other.transform.position;

            //     if (thisPos.y < otherPos.y || (thisPos.y == otherPos.y && thisPos.x < otherPos.x))
            //     {
            //         Vector2 collisionPoint = other.contacts[0].point;
            //         int level = int.Parse(this.transform.name[6].ToString());

            //         fruitManager.EvolutionFruit(collisionPoint, level);
            //     }
            //     Destroy(this.gameObject);
            // }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "GameOver" && isDropped)
        {
            GameManager.Instance.isGameOver = true;
            fruitManager.DeactivateComponent();
            StartCoroutine(GameManager.Instance.GameOver());
        }
    }
}

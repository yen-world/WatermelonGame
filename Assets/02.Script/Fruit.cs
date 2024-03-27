using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    FruitManager fruitManager;
    bool isDropped = false;

    // Start is called before the first frame update
    void Start()
    {
        fruitManager = FindObjectOfType<FruitManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isDropped)
        {
            isDropped = true;
            fruitManager.GetNextFruit();
            fruitManager.CreateFruit();
        }

        if (other.transform.name == this.name)
        {
            // Vector2 collisionPoint = other.contacts[0].point;
            // int fruitLevel = int.Parse(this.name[6].ToString());
            print(transform.position.y);
            // // fruitManager.EvolutionFruit(collisionPoint, fruitLevel);
            // fruitManager.dataList.Add(new CollisionData(collisionPoint, fruitLevel));
            if (other.transform.position.y < this.transform.position.y)
            {
                Destroy(other.gameObject);
            }
        }

    }
}

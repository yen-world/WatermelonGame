using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    FruitManager fruitManager;

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
        if (other.transform.tag == "Fruit")
        {
            if (other.transform.name == this.name)
            {
                print(this.name);
            }
        }
    }
}

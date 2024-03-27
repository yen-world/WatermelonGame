using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropCheck : MonoBehaviour
{
    FruitManager fruitManager;
    bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        fruitManager = FindObjectOfType<FruitManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (!hasCollided)
    //     {
    //         hasCollided = true;
    //         fruitManager.GetNextFruit();
    //         fruitManager.CreateFruit();

    //         // 과일 프리팹에 Fruit 스크립트를 부착하고, DropCheck 스크립트는 제거
    //         Destroy(GetComponent<DropCheck>());
    //         this.AddComponent<Fruit>();
    //     }
    // }
}

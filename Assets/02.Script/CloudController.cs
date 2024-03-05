using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    Vector2 vector;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -1.75f)
            {
                vector.Set(-1, 0);
                this.transform.Translate(vector * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x < 3.3f)
            {
                vector.Set(1, 0);
                this.transform.Translate(vector * speed * Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}

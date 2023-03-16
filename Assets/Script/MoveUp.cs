using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= transform.up * speed;
        if (gameObject.transform.position.y < 4)
        {
            speed *= -1;
        }
        if (gameObject.transform.position.y > 9)
        {
            speed *= -1;
        }
    }
}

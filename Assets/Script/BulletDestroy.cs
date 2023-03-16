using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("No Hit");
        if (collision.gameObject.CompareTag("Cube") && gameObject.CompareTag("Bullet"))
        {

            Destroy(gameObject);

            Debug.Log("Bullet delete");
        }
    }
}

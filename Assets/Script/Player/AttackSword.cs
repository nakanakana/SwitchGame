using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    private CapsuleCollider CapCol;

    float DelayTimer = 5.0f;

    //Start is called before the first frame update
    void Start()
    {
        CapCol = GetComponent<CapsuleCollider>();

        DelayTimer = 5.0f;
    }

    //Update is called once per frame
    void Update()
    {

        DelayTimer -= Time.deltaTime;
        if (DelayTimer <= 1.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {

                CapCol.enabled = true;
                DelayTimer = 5.0f;
            }
            else
            {
                CapCol.enabled = false;
            }
        }
            
    }

    void OnCollisionEnter(Collision collision)
    {
        // 剣で当たったオブジェクトが敵である場合
        if (CapCol.enabled == true && collision.gameObject.CompareTag("Enemy"))
        {
            // 敵を削除する
            Destroy(collision.gameObject);

        }
    }
}

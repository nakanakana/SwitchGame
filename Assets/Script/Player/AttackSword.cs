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

    ////Update is called once per frame
    void Update()
    {

        DelayTimer -= Time.deltaTime;
        if (DelayTimer <= 3.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {

                CapCol.enabled = true;
                Debug.Log("TRUE");
                DelayTimer = 5.0f;
             
            }
            else if(DelayTimer >= 4.5f)
            {
                CapCol.enabled = false;
                Debug.Log("FALSE");
            }
        }


        //void OnTriggerEnter(Collider col)
        //{
        //    if (col.tag == "Enemy")
        //    {
        //        Debug.Log("敵に当たった");
        //        col.GetComponent<Enemy>().SetState(Enemy.EnemyState.Damage);
        //    }
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        // 剣で当たったオブジェクトが敵である場合
        if (collision.gameObject.tag == "Enemy")
        {
            // 敵を削除する
            Destroy(collision.gameObject, 0.2f);

        }
    }
}

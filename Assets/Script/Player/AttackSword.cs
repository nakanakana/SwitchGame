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
        //        Debug.Log("�G�ɓ�������");
        //        col.GetComponent<Enemy>().SetState(Enemy.EnemyState.Damage);
        //    }
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        // ���œ��������I�u�W�F�N�g���G�ł���ꍇ
        if (collision.gameObject.tag == "Enemy")
        {
            // �G���폜����
            Destroy(collision.gameObject, 0.2f);

        }
    }
}

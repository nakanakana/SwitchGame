using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    private CapsuleCollider CapCol;

    // Start is called before the first frame update
    void Start()
    {
        CapCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            CapCol.enabled = true;

        }
        else
        {
            CapCol.enabled = false;
        }
    }

   //void OnCollisionEnter(Collision collision)
   // {
   //     // ���œ��������I�u�W�F�N�g���G�ł���ꍇ
   //     if (CapCol.enabled == true && collision.gameObject.CompareTag ("Enemy"))
   //     {
   //         // �G���폜����
   //         Destroy(collision.gameObject);

   //     }
   // }
}

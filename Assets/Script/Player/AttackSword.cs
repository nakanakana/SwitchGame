using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        // ���œ��������I�u�W�F�N�g���G�ł���ꍇ
        if (gameObject.CompareTag ("Enemy"))
        {
            // �G���폜����
            Destroy(other.gameObject);

        }
    }
}

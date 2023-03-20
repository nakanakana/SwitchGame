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
        // 剣で当たったオブジェクトが敵である場合
        if (gameObject.CompareTag ("Enemy"))
        {
            // 敵を削除する
            Destroy(other.gameObject);

        }
    }
}

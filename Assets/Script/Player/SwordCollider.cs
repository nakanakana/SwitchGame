using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private SphereCollider spCollider;

    void Start()
    {
        // ゲームオブジェクトにアタッチされた BoxCollider コンポーネントを取得
        spCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        // 左クリックされた時のみ、Box Collider を有効化する
        if (Input.GetMouseButtonDown(0))
        {
            spCollider.enabled = true;
        }
        else
        {
            spCollider.enabled = false;
            Debug.Log(false);
        }
    }
}


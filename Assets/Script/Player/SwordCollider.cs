using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private BoxCollider boxCollider;

    void Start()
    {
        // ゲームオブジェクトにアタッチされた BoxCollider コンポーネントを取得
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // 左クリックされた時のみ、Box Collider を有効化する
        if (Input.GetMouseButtonDown(0))
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
            Debug.Log(false);
        }
    }
}


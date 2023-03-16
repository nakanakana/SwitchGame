using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObj : MonoBehaviour
{
    //クリック数をカウントする
    int clickcnt = 0;
    //オブジェクトの位置を管理する配列
    //[SerializeField] Transform[] trans;
    //他から呼び出せるようにするためのインスタンス
    static public SwitchObj instance;
    GameObject gameObject1 = null;
    GameObject gameObject2 = null;
    //public GameObject firstObject;
    //public GameObject secondObject;

    //private Vector3 firstObjectPosition;
    //private Vector3 secondObjectPosition;

    private void Start()
    {
        gameObject1 = GameObject.Find("Player");
        //firstObjectPosition = firstObject.transform.position;
        //secondObjectPosition = secondObject.transform.position;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(1))
            {
                gameObject2 = hit.collider.gameObject;
            }
        }
        if (gameObject2 != null)
        {
            // オブジェクトの位置を交換する
            if (gameObject2.CompareTag("Cube") && gameObject1.name == ("Player")
            /*|| gameObject1.CompareTag("Cube") && gameObject2.name == ("Player")*/)
            {
                SwapObj(gameObject1, gameObject2);
                clickcnt = 0;
                gameObject2 = null;
            }
            else
            {
                clickcnt = 0;
                gameObject2 = null;
            }
        }

        //if (clickcnt == 0)
        //{
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        if (Input.GetMouseButtonDown(1))
        //        {
        //            gameObject1 = hit.collider.gameObject;
        //            //trans[0] = hit.collider.transform;
        //            //firstObject.transform.position = hit.collider.transform.position;
        //            //Debug.Log(hit.collider.transform.position);
        //            //Debug.Log(gameObject1.name + " obj1");
        //            clickcnt++;
        //        }
        //    }
        //}
        //else if (clickcnt == 1)
        //{
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        if (Input.GetMouseButtonDown(1))
        //        {
        //            gameObject2 = hit.collider.gameObject;

        //            //trans[1] = hit.collider.transform;
        //            //secondObject.transform.position = hit.collider.transform.position;
        //            //Debug.Log(hit.collider.transform.position);

        //            // 配列の位置を交換する
        //            //SwapArray();
        //            //Debug.Log(gameObject2.name + " obj2");
        //        }
        //    }
        //    if (gameObject1 != null && gameObject2 != null)
        //    {
        //        // オブジェクトの位置を交換する
        //        if (gameObject1.CompareTag("Cube") && gameObject2.name == ("Player")
        //            || gameObject2.CompareTag("Cube") && gameObject1.name == ("Player"))
        //        {
        //            SwapObj(gameObject1, gameObject2);
        //            clickcnt = 0;
        //            //Debug.Log("change");
        //        }
        //        else
        //        {
        //            clickcnt = 0;
        //            gameObject1 = null;
        //            gameObject2 = null;
        //            //Debug.Log("No change& null");
        //        }
        //    }
        //}
        //Debug.Log(clickcnt);
    }
    //public void OnclickBook(Book.COLOR color,Transform transform)
    //{
    //    //クリックされたらオブジェクトの位置を保存
    //    //2回目のクリックでスワップする
    //    if (clickcnt == 0)
    //    {
    //        //if (Input.GetMouseButtonDown(0))
    //        //{
    //            trans[0] = transform;
    //            index1 = Array.IndexOf(input, color);
    //            clickcnt++;
    //        //}
    //    }
    //    else if (clickcnt == 1)
    //    {
    //        //if (Input.GetMouseButtonDown(0))
    //        //{
    //            trans[1] = transform;
    //            index2 = Array.IndexOf(input, color);
    //            // オブジェクトの位置を交換する
    //            SwapObj();
    //            // 配列の位置を交換する
    //            SwapArray();

    //            clickcnt = 0;
    //        //}
    //    }
    //}

    void SwapObj(GameObject gameObject1, GameObject gameObject2)
    {
        // オブジェクトの位置関係をスワップする
        Vector3 tmp = gameObject1.transform.position;
        gameObject1.transform.position = gameObject2.transform.position;
        gameObject2.transform.position = tmp;
        //Vector3 tmp = firstObject.transform.position;
        //firstObject.transform.position = secondObject.transform.position;
        //secondObject.transform.position = tmp;
    }

    //public void SwapArray()
    //{
    //    // 色をスワップする
    //    var tmp = input[index1];
    //    input[index1] = input[index2];
    //    input[index2] = tmp;
    //}


    // リセットボタンが押されたら、位置を初期位置に戻す
    //public void ResetPositions()
    //{
    //    gameObject1 = null;
    //    gameObject2 = null;

    //    Debug.Log("delete");
    //}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObj : MonoBehaviour
{
    //�N���b�N�����J�E���g����
    int clickcnt = 0;
    //�I�u�W�F�N�g�̈ʒu���Ǘ�����z��
    //[SerializeField] Transform[] trans;
    //������Ăяo����悤�ɂ��邽�߂̃C���X�^���X
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
        ;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(1))
            {
                gameObject2 = hit.collider.gameObject;
            }
        }
        if (gameObject2 != null)
        {
            // �I�u�W�F�N�g�̈ʒu����������
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

        //            // �z��̈ʒu����������
        //            //SwapArray();
        //            //Debug.Log(gameObject2.name + " obj2");
        //        }
        //    }
        //    if (gameObject1 != null && gameObject2 != null)
        //    {
        //        // �I�u�W�F�N�g�̈ʒu����������
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
    //    //�N���b�N���ꂽ��I�u�W�F�N�g�̈ʒu��ۑ�
    //    //2��ڂ̃N���b�N�ŃX���b�v����
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
    //            // �I�u�W�F�N�g�̈ʒu����������
    //            SwapObj();
    //            // �z��̈ʒu����������
    //            SwapArray();

    //            clickcnt = 0;
    //        //}
    //    }
    //}

    void SwapObj(GameObject gameObject1, GameObject gameObject2)
    {
        // �I�u�W�F�N�g�̈ʒu�֌W���X���b�v����
        Vector3 tmp = gameObject1.transform.position;
        gameObject1.transform.position = gameObject2.transform.position;
        gameObject2.transform.position = tmp;
        //Vector3 tmp = firstObject.transform.position;
        //firstObject.transform.position = secondObject.transform.position;
        //secondObject.transform.position = tmp;
    }

    //public void SwapArray()
    //{
    //    // �F���X���b�v����
    //    var tmp = input[index1];
    //    input[index1] = input[index2];
    //    input[index2] = tmp;
    //}


    // ���Z�b�g�{�^���������ꂽ��A�ʒu�������ʒu�ɖ߂�
    //public void ResetPositions()
    //{
    //    gameObject1 = null;
    //    gameObject2 = null;

    //    Debug.Log("delete");
    //}
}
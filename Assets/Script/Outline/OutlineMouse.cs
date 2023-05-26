using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMouse : MonoBehaviour
{
    private bool isMouseOver = false;
    private Outline outline;
    private Vector3 ConPosPre = Vector3.zero;
    Ray ray;
    GameObject gameObject2 = null;
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    //void OnMouseEnter()
    //{
    //    isMouseOver = true;
    //}

    //void OnMouseExit()
    //{
    //    isMouseOver = false;
    //    outline.enabled = false;
    //}

    void Update()
    {
        Vector3 _imgRect = TestUIRay.instance._imgRect.position;
       
        ray = Camera.main.ScreenPointToRay(TestUIRay.instance.GetUIScreenPos(TestUIRay.instance._imgRect));
        

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            gameObject2 = hit.collider.gameObject;
            if (gameObject2.CompareTag("Cube"))
            {
                outline.enabled = true;
            }
            else
            {
                outline.enabled = false;
            }
        }
        else
        {
            outline.enabled = false;
        }


        //if (isMouseOver)
        //{
        //    outline.enabled = true;
        //}
        //else
        //{
        //    outline.enabled = false;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMouse : MonoBehaviour
{
    private bool isMouseOver = false;
    private Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        outline.enabled = false;
    }

    void Update()
    {
        if (isMouseOver)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }
}

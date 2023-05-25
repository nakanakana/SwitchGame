using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestUIRay : MonoBehaviour
{
    public Canvas canvas;
    public RectTransform _imgRect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _imgRect.position=Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(GetUIScreenPos(_imgRect));
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

    }


    Vector2 GetUIScreenPos(RectTransform rt)
    {

        return RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rt.position);
    }
}

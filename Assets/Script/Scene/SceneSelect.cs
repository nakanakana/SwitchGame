using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelect : MonoBehaviour
{
    public string SelectScene;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 光線を飛ばす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            // もし何かに当たったら
            if (Physics.Raycast(ray, out hit))
            {
                Application.LoadLevel(SelectScene);
            }
            else
            {
                return;
            }
            
        }
    }
}


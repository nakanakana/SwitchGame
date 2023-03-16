using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Tracking : MonoBehaviour
{

    public GameObject playerObject;                     //追尾 オブジェクト
    //public Vector2 rotationSpeed = new Vector2(3, 3);    //回転速度
    private Vector2 lastMousePosition;                  //最後のマウス座標
    private Vector3 lastTargetPosition;                 //最後の追尾オブジェクトの座標


    private float zoom;

    void Start()
    {
        zoom = 0.0f;
        lastMousePosition.x = 0;
        lastMousePosition.y = 0;

        lastTargetPosition = playerObject.transform.position;
    }

    void Update()
    {

        Rotate();
        //Zoom();
    }


    void Rotate()
    {
        transform.position += playerObject.transform.position - lastTargetPosition;
        lastTargetPosition = playerObject.transform.position;

        //Vector2 nowMouseValue;
        //nowMouseValue.x = Input.GetAxisRaw("Mouse X");
        //nowMouseValue.y = Input.GetAxisRaw("Mouse Y");

        //Vector3 newAngle = Vector3.zero;
        //newAngle.x = rotationSpeed.x * nowMouseValue.x;
        //newAngle.y = rotationSpeed.y * nowMouseValue.y;
        // Updated upstream

        //transform.RotateAround(playerObject.transform.position, Vector3.up, newAngle.x);
        //transform.RotateAround(playerObject.transform.position, transform.right, -newAngle.y);
       


        //transform.RotateAround(playerObject.transform.position, Vector3.up, newAngle.x);
        //transform.RotateAround(playerObject.transform.position, transform.right, -newAngle.y);


    }

    //拡大縮小
    //void Zoom()
    //{
    //    zoom = Input.GetAxis("Mouse ScrollWheel");
    //    Vector3 offset = new Vector3(0, 0, 0);
    //    Vector3 pos = playerObject.transform.position - transform.position;

    //    if (zoom > 0)
    //    {
    //        offset = pos.normalized * 1;
    //    }
    //    else if (zoom < 0)
    //    {
    //        offset = -pos.normalized * 1;

    //    }
    //    transform.position = transform.position + offset;
    //}
}

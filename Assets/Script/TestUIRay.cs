using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestUIRay : MonoBehaviour
{
    static public TestUIRay instance;

    public Canvas canvas;
    public RectTransform _imgRect;

    public Vector3 i;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField]
    private float moveSpeed;

    //public string horizontalAxis = "ControllerHorizontal";
    public string horizontalAxis = "Horizontal";
    //public string verticalAxis = "ControllerVertical";
    public string verticalAxis = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var controllerNames = Input.GetJoystickNames();
        if (controllerNames[0] == "")
        {
            Cursor.visible = false;
            _imgRect.position = Input.mousePosition;

        }
        else
        {
            Cursor.visible = true;
        }



            i = _imgRect.position;

        // コントローラーの水平方向の入力値を取得
        float horizontalInput = Input.GetAxis(horizontalAxis);

        // コントローラーの垂直方向の入力値を取得
        float verticalInput = Input.GetAxis(verticalAxis);

        //if(horizontalInput == 1 || horizontalInput == -1)
        //{
        //    i.x += horizontalInput;
        //}

        //if(verticalInput == 1 || verticalInput == -1)
        //{
        //    i.y -= verticalInput;
        //}
        if (horizontalInput >= 1)
        {
            i.x += horizontalInput * moveSpeed;

        }
            
        if(horizontalInput <= -1)
        {
            i.x += horizontalInput * moveSpeed;
        }

        if (verticalInput >= 1 )
        {
            i.y -= verticalInput * moveSpeed;
        }

        if (verticalInput <= -1)
        {
            i.y -= verticalInput * moveSpeed;
        }

        //_imgRect.position=Input.mousePosition;
        _imgRect.position = i;
        
        
        //ray
        Ray ray = Camera.main.ScreenPointToRay(GetUIScreenPos(_imgRect));
       // Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

    }


    public Vector2 GetUIScreenPos(RectTransform rt)
    {

        return RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rt.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TestUIRay : MonoBehaviour
{
    static public TestUIRay instance;

    public Canvas canvas;
    public RectTransform _imgRect;

    public Vector3 i;

    [Header("Axis/ボタン名")]
    public string horizontalAxisString = "Horizontal";
    public string verticalAxisString = "Vertical";
    public string submitKeyString = "Submit";	//決定
    [Header("カーソル移動スピード")]
    public float horizontalSpeed = 1000.0f;
    public float verticalSpeed = 1000.0f;

    [Header("カーソルのRectTransform")]
    public RectTransform cursorRect;

    [Header("画面端判断用Rect")]
    public RectTransform boundaries;

    ///<summary> PCマウスカーソル表示制御用 </summary>
    private bool usingDesktopCursor = true;

    ///<summary> マウス入力されているか </summary>
    private bool mHasSwitchedToVirtualMouse = false;

    ///<summary> コントローラー入力 </summary>
    bool mHasSwitchedToController = false;

    [Header("マウスInputModule")]
    public GameObject mouseInputModule;

    ///<summary> カーソル座標 最小値 </summary>
    private Vector2 mMinPos = Vector2.zero;

    ///<summary> カーソル座標 最大値 </summary>
    private Vector2 mMaxPos = Vector2.zero;

    ///<summary> カーソル移動量 </summary>
    
   
   // public GameObject cursorObject = null;


   
    /// <summary>
    /// 入力デバイス
    /// </summary>
    enum InputState
    {
        MouseKeyboard,
        Controler
    };
    private InputState mInputState = InputState.MouseKeyboard;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void OnGUI()
    {
        //EventはOnGUIの中でのみ受け取れるのでここで実行
        DeviceChangeCheck();
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
        //カーソル座標制限用座標計算
        mMinPos.x = (boundaries.rect.width / 2f) * -1f;
        mMaxPos.x = (boundaries.rect.width / 2f) - cursorRect.rect.width / 18f; //

        mMinPos.y = (boundaries.rect.height / 2f) * -1f + cursorRect.rect.height / 18f; //
        mMaxPos.y = (boundaries.rect.height / 2f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (usingDesktopCursor)
        {
            Cursor.visible = true;  //PCのマウスカーソル表示
            if (!mHasSwitchedToVirtualMouse)
            {
                SwitchToMouse();
                
            }
            
        }
        else if (!usingDesktopCursor && !mHasSwitchedToController)
        {
            Cursor.visible = false; //PCのマウスカーソル非表示
            if (!mHasSwitchedToController)
            {
                SwitchToController();
            }
        }



        //var controllerNames = Input.GetJoystickNames();
        //if (controllerNames.Length <=0)
        //{
        //    Cursor.visible = false;
        //    _imgRect.position = Input.mousePosition;

        //}
        //else
        //{
        //    Cursor.visible = true;
        //}
        


            i = _imgRect.position;



        if (!usingDesktopCursor)
        {
           

            // コントローラーの水平方向の入力値を取得
            float horizontalInput = Input.GetAxis(horizontalAxis);

            // コントローラーの垂直方向の入力値を取得
            float verticalInput = Input.GetAxis(verticalAxis);

            if (horizontalInput == 1 || horizontalInput == -1)
            {
                i.x += horizontalInput * moveSpeed;
            }
         
            // cursorRect.anchoredPosition += new Vector2(mMovementX, mMovementY);






            //_imgRect = cursorRect;
            if (verticalInput == 1 || verticalInput == -1)
            {
                i.y -= verticalInput * moveSpeed;
            }
            //if (horizontalInput >= 1)
            //{
            //    i.x += horizontalInput * moveSpeed;

            //}

            //if (horizontalInput <= -1)
            //{
            //    i.x += horizontalInput * moveSpeed;
            //}

            //if (verticalInput >= 1)
            //{
            //    i.y -= verticalInput * moveSpeed;
            //}

            //if (verticalInput <= -1)
            //{
            //    i.y -= verticalInput * moveSpeed;
            //}
            _imgRect.position = i;
        }
        else if (usingDesktopCursor)
        {
            _imgRect.position = Input.mousePosition;
        }


        Vector3 tPos3;
        tPos3.x = Mathf.Clamp(_imgRect.anchoredPosition.x, mMinPos.x, mMaxPos.x);
        tPos3.y = Mathf.Clamp(_imgRect.anchoredPosition.y, mMinPos.y, mMaxPos.y);
        tPos3.z = 0f;
        _imgRect.anchoredPosition = tPos3;
        _imgRect.transform.localPosition = tPos3;
        //_imgRect.position=Input.mousePosition;
        //  



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

    /// <summary>
    /// マウス入力チェック
    /// </summary>
    /// <returns></returns>
    private bool isMouseKeyboard()
    {
     

        // マウスのボタン
        if (Event.current.isMouse)
        {
            return true;
        }

        if (Mathf.Abs(Input.GetAxis("Mouse X")) > Mathf.Epsilon ||
            Mathf.Abs(Input.GetAxis("Mouse Y")) > Mathf.Epsilon)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// キーボード＆コントローラーチェック
    /// </summary>
    /// <returns></returns>
    private bool isControlerInput()
    {
        //ジョイスティック1のボタンをチェック
        // ※KeyCode.Joystick1Button19まである
        // for (int i = 0; i < 19; i++)
        //{
        //    //KeyCode tKeyCode = KeyCode.Joystick1Button0 + i;
        //    //if (Input.GetKey(tKeyCode))
        //    //{
        //    //    return true;
        //    //}
        //}
        float horizontalInput = Input.GetAxis(horizontalAxis);
        //
        //// コントローラーの垂直方向の入力値を取得
        float verticalInput = Input.GetAxis(verticalAxis);
        ////ジョイスティック入力
        if (horizontalInput <= -1 || horizontalInput >=1||
             verticalInput <= -1|| verticalInput >= 1)
        {
           
            return true;
        }
        return false;
    }


    /// <summary>
    /// マウスモードに変更
    /// </summary>
    void SwitchToMouse()
    {
        mHasSwitchedToVirtualMouse = true;
        mHasSwitchedToController = false;
        //GetComponent<EventSystem>().enabled = false;
       // mouseInputModule.SetActive(true);
       // cursorObject.SetActive(false);
       //_imgRect.position.x
    }

    /// <summary>
    /// キーボードモードに変更
    /// </summary>
    void SwitchToController()
    {
        mHasSwitchedToVirtualMouse = false;
        mHasSwitchedToController = true;
      //  mouseInputModule.SetActive(false);
      // GetComponent<EventSystem>().enabled = true;
       // cursorObject.SetActive(true);
    }
    void DeviceChangeCheck()
    {
        string tStr;

        switch (mInputState)
        {
            case InputState.MouseKeyboard:
                if (isControlerInput())
                {
                    mInputState = InputState.Controler;
                    usingDesktopCursor = false;
                    Debug.Log("モード：マウス");
                }
                tStr = "モード：マウス\n";
               // textDebug.text = tStr + Input.mousePosition.ToString();
                break;

            case InputState.Controler:
                if (isMouseKeyboard())
                {
                    mInputState = InputState.MouseKeyboard;
                    usingDesktopCursor = true;
                    Debug.Log("モード：コントローラー&キーボード");
                }
                tStr = "モード：コントローラー&キーボード\n";
               // textDebug.text = tStr + mPointerEventData.position.ToString();
                break;
        }
    }
}

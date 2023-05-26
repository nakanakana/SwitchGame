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

    [Header("Axis/�{�^����")]
    public string horizontalAxisString = "Horizontal";
    public string verticalAxisString = "Vertical";
    public string submitKeyString = "Submit";	//����
    [Header("�J�[�\���ړ��X�s�[�h")]
    public float horizontalSpeed = 1000.0f;
    public float verticalSpeed = 1000.0f;

    [Header("�J�[�\����RectTransform")]
    public RectTransform cursorRect;

    [Header("��ʒ[���f�pRect")]
    public RectTransform boundaries;

    ///<summary> PC�}�E�X�J�[�\���\������p </summary>
    private bool usingDesktopCursor = true;

    ///<summary> �}�E�X���͂���Ă��邩 </summary>
    private bool mHasSwitchedToVirtualMouse = false;

    ///<summary> �R���g���[���[���� </summary>
    bool mHasSwitchedToController = false;

    [Header("�}�E�XInputModule")]
    public GameObject mouseInputModule;

    ///<summary> �J�[�\�����W �ŏ��l </summary>
    private Vector2 mMinPos = Vector2.zero;

    ///<summary> �J�[�\�����W �ő�l </summary>
    private Vector2 mMaxPos = Vector2.zero;

    ///<summary> �J�[�\���ړ��� </summary>
    
   
   // public GameObject cursorObject = null;


   
    /// <summary>
    /// ���̓f�o�C�X
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
        //Event��OnGUI�̒��ł̂ݎ󂯎���̂ł����Ŏ��s
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
        //�J�[�\�����W�����p���W�v�Z
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
            Cursor.visible = true;  //PC�̃}�E�X�J�[�\���\��
            if (!mHasSwitchedToVirtualMouse)
            {
                SwitchToMouse();
                
            }
            
        }
        else if (!usingDesktopCursor && !mHasSwitchedToController)
        {
            Cursor.visible = false; //PC�̃}�E�X�J�[�\����\��
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
           

            // �R���g���[���[�̐��������̓��͒l���擾
            float horizontalInput = Input.GetAxis(horizontalAxis);

            // �R���g���[���[�̐��������̓��͒l���擾
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
    /// �}�E�X���̓`�F�b�N
    /// </summary>
    /// <returns></returns>
    private bool isMouseKeyboard()
    {
     

        // �}�E�X�̃{�^��
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
    /// �L�[�{�[�h���R���g���[���[�`�F�b�N
    /// </summary>
    /// <returns></returns>
    private bool isControlerInput()
    {
        //�W���C�X�e�B�b�N1�̃{�^�����`�F�b�N
        // ��KeyCode.Joystick1Button19�܂ł���
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
        //// �R���g���[���[�̐��������̓��͒l���擾
        float verticalInput = Input.GetAxis(verticalAxis);
        ////�W���C�X�e�B�b�N����
        if (horizontalInput <= -1 || horizontalInput >=1||
             verticalInput <= -1|| verticalInput >= 1)
        {
           
            return true;
        }
        return false;
    }


    /// <summary>
    /// �}�E�X���[�h�ɕύX
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
    /// �L�[�{�[�h���[�h�ɕύX
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
                    Debug.Log("���[�h�F�}�E�X");
                }
                tStr = "���[�h�F�}�E�X\n";
               // textDebug.text = tStr + Input.mousePosition.ToString();
                break;

            case InputState.Controler:
                if (isMouseKeyboard())
                {
                    mInputState = InputState.MouseKeyboard;
                    usingDesktopCursor = true;
                    Debug.Log("���[�h�F�R���g���[���[&�L�[�{�[�h");
                }
                tStr = "���[�h�F�R���g���[���[&�L�[�{�[�h\n";
               // textDebug.text = tStr + mPointerEventData.position.ToString();
                break;
        }
    }
}

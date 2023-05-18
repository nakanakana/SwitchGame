using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDevice : MonoBehaviour
{
    [Header("�v���C���[���Z�b�g")]
    public GameObject player;
   
    private AudioSource audioSource;
    [Header("�ʂɉ����w�肵�����Ȃ炢���")]
    public AudioClip sound;
 
    private float aleartCount= 0.0f;
    [Header("���Ăق����G���Z�b�g")]
    public GameObject[] enemy;

    [Header("���b�Ԗ炵�����邩")]
    public float aleartTime;

    //[Header("���[�v�����邩�ۂ�(�f�t�H���g�̓��[�v���Ȃ�)")]
    private bool loopFlag;

    //�炵��Ƃ̋����ۑ��p
    private float dist = 0.0f;

    //�点��͈�
    private float range = 1.5f;

    //�G��������点�Ȃ��Ȃ�͈�
    private float eRange = 1.7f;

    //�f�o�C�X���g�p�󋵂��ǂ��� true : �g�p�� false : ���g�p
    private bool deviceFlag = false;

    private MoveControl moveControl;


    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        moveControl = player.GetComponent<MoveControl>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;


        if (deviceFlag)
        {
            aleartCount += Time.deltaTime;

        }
        if (aleartCount >= aleartTime)
        {
            //foundFlag = false;
            aleartCount = 0.0f;
            //FlushController.instance.flushClear();
            Alert.instance.ReleaseAleart();
            deviceFlag = false;
        }



        if (JudgeDistance())
        {

            return;
        }

        if (dist < range)
        {
            moveControl.IsAttack = false;
            if (Input.GetMouseButtonDown(0) && !Alert.instance.GetisAlert())
            {
               
                if (sound != null)
                {
                    Alert.instance.OnAleart(sound, loopFlag);
                }
                else
                {
                    Alert.instance.OnAleart(loopFlag);

                }
              
                Alert.instance.CallEnemy(enemy, transform);
                //aleartTime = 0.0f;
                deviceFlag = true;
            }
        }
        else
        {
            moveControl.IsAttack = true;
        }
      
    }
    private void CallEnemy()
    {
        for (int i = 0; i < enemy.Length; ++i)
        {
            if (enemy[i] != null)
            {
                enemy[i].GetComponentInChildren<Patrol>().AlertCome(transform);
            }
        }
    }

    private bool JudgeDistance()
    {
        float eDist;
        for (int i = 0; i < enemy.Length; ++i)
        {
            if (enemy[i] != null)
            {
                eDist=Vector3.Distance(enemy[i].transform.position, this.transform.position);
                if (eDist < 1.7f)
                {
                    return true;

                }
            }
        }


        return false;
    }

}

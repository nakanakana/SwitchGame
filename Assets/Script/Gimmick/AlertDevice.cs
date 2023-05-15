using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDevice : MonoBehaviour
{
    [Header("プレイヤーをセット")]
    public GameObject player;
   
    private AudioSource audioSource;
    [Header("個別に音を指定したいならいれて")]
    public AudioClip sound;
 
    private float aleartCount= 0.0f;
    [Header("来てほしい敵をセット")]
    public GameObject[] enemy;

    [Header("何秒間鳴らし続けるか")]
    public float aleartTime;

    [Header("ループさせるか否か(デフォルトはループしない)")]
    public bool loopFlag;

    //鳴らし手との距離保存用
    private float dist = 0.0f;

    //デバイスが使用状況かどうか true : 使用中 false : 未使用
    private bool deviceFlag = false;



    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        
        if (dist < 1.5f)
        {

            if (Input.GetMouseButtonDown(0) && !Alert.instance.GetisAlert())
            {
                if (sound != null)
                {
                    Alert.instance.OnAleart(sound,loopFlag);
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
        Debug.Log(aleartCount);
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
}

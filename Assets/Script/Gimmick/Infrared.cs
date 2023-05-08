using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infrared : MonoBehaviour
{
    //public AudioClip sound;
    public float maxDistance = 50f;
    private LineRenderer lr;
   // private AudioSource audioSource;
    private bool foundFlag = false;
    private float countTime = 0.0f;
    [Header("来てほしい敵をセット")]
    public GameObject[] enemy;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue);


        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        lr.SetPosition(0, ray.origin);
        // Debug.Log(foundFlag);
        // Debug.Log(countTime);

        //レーザーとプレイヤーの判定
        //当たれば警報が鳴り、レーザーがプレイヤーで遮られる
        //既に見つかっていればなにもしない
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lr.SetPosition(1, hit.point);


            if (hit.transform.CompareTag("Player") && !Alert.instance.GetisAlert())
            {
                //print("侵入者発見");
                // 警報音を鳴らす。
                //audioSource.clip = sound;
                //audioSource.Play();
             
                Alert.instance.OnAleart();
                Alert.instance.CallEnemy(enemy, transform);
                foundFlag = true;
            }
        }
        else
        {
            lr.SetPosition(1, ray.origin + ray.direction * maxDistance);

        }

        //ひとまず一定時間で鳴り止むようにしている。
        if (countTime >= 7)
        {
            foundFlag = false;
            countTime = 0.0f;
            //FlushController.instance.flushClear();
            Alert.instance.ReleaseAleart();
            // audioSource.Stop();
        }


        //見つかっているなら鳴っている時間のカウントを始める    
        if (foundFlag)
        {
            countTime += Time.deltaTime;
            // FlushController.instance.flush();
            
        }

       

    }
}

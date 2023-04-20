using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSensing : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound;
    private bool foundFlag = false;
    private float countTime = 0.0f;
    public GameObject enemy_01;
    public GameObject enemy_02;
    public GameObject enemy_03;
    public GameObject enemy_04;
    private Patrol patrol_01;
    private Patrol patrol_02;
    private Patrol patrol_03;
    private Patrol patrol_04;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (enemy_01 != null)
        {
            patrol_01 = enemy_01.GetComponentInChildren<Patrol>();
        }
        if (enemy_02 != null)
        {
            patrol_02 = enemy_02.GetComponentInChildren<Patrol>();
        }
        if (enemy_03 != null)
        {
            patrol_03 = enemy_01.GetComponentInChildren<Patrol>();
        }
        if (enemy_04 != null)
        {
            patrol_04 = enemy_01.GetComponentInChildren<Patrol>();
        }
    }
    // Update is called once per frame
    void Update()
    {


        //ひとまず一定時間で鳴り止むようにしている。
        if (countTime >= 7)
        {
            foundFlag = false;
            countTime = 0.0f;
            Alert.instance.ReleaseAleart();
            // FlushController.instance.flushClear();
            // audioSource.Stop();
            
        }
        //見つかっているなら鳴っている時間のカウントを始める   
        if (foundFlag)
        {
            countTime += Time.deltaTime;
            // FlushController.instance.flush();
            CallEnemy();
        }
      
           

       
        //Debug.Log(foundFlag);

    }

    //踏んだ瞬間に音が鳴るようにしているため、既に音が鳴っている状態でこれを踏んでいると、
    //鳴り終わった跡再び音がならないので改修する必要あり
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //audioSource.clip = sound;
            //audioSource.Play();
           
            if (!Alert.instance.GetisAlert())
            {
                foundFlag = true;
            }
            //Alert.instance.OnAleart();
           



        }
    }

    private void CallEnemy()
    {
        if (enemy_01 != null)
        {
            patrol_01.AlertCome(this.transform);
        }

        if (enemy_02 != null)
        {
            patrol_02.AlertCome(this.transform);
        }

        if (enemy_03 != null)
        {
            patrol_03.AlertCome(this.transform);
        }

        if (enemy_04 != null)
        {
            patrol_04.AlertCome(this.transform);
        }

    }

    //void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    //{
    //    if (other.gameObject.tag=="Player")
    //    {
    //        audioSource.clip = sound;
    //        audioSource.Play();
           
    //        foundFlag = true;
    //    }
       
    //}
}

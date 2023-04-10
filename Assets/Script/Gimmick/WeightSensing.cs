using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSensing : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound;
    private bool foundFlag = false;
    private float countTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            Alert.instance.OnAleart();
           
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

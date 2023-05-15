using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSensing : MonoBehaviour
{
    private AudioSource audioSource;
    //[Header("個別に音を指定したいならいれて")]
    [Header("これは個別に鳴らすようにしているので音を指定して")]
    [Header("AudioSourceの方のLoopにチェック入れてください")]
    public  AudioClip sound;

    private MeshRenderer mesh;

    private bool foundFlag = false;
   // private float countTime = 0.0f;

    [Header("来てほしい敵をセット")]
    public GameObject[] enemy;
  


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       

        
        //mesh = GetComponent<MeshRenderer>();
        //if (mesh.enabled)
        //{
        //    mesh.enabled = false;
        //}
    }
    // Update is called once per frame
    void Update()
    {


        
        //if (foundFlag&&!audioSource.isPlaying)
        //{
        //    audioSource.Stop();
        //    //countTime = 0.0f;
        //    foundFlag = false;
        //    // FlushController.instance.flushClear();
        //    // audioSource.Stop();

        //}
        //見つかっているなら鳴っている時間のカウントを始める   
        //if (foundFlag)
        //{
        //    countTime += Time.deltaTime;
        //    // FlushController.instance.flush();
            
        //}
      
           

       
        //Debug.Log(foundFlag);

    }

    //踏んだ瞬間に音が鳴るようにしているため、既に音が鳴っている状態でこれを踏んでいると、
    //鳴り終わった跡再び音がならないので改修する必要あり
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                    
            audioSource.clip = sound;
            audioSource.Play();
            Alert.instance.CallEnemy(enemy, transform);
            foundFlag = true;            
            
            // Alert.instance.OnAleart();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            audioSource.Stop();
            //countTime = 0.0f;
            foundFlag = false;
            Alert.instance.ReleaseEnemy();
            // Alert.instance.OnAleart();
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

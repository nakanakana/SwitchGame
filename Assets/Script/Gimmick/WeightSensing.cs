using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSensing : MonoBehaviour
{
    private AudioSource audioSource;
    //[Header("�ʂɉ����w�肵�����Ȃ炢���")]
    [Header("�����ɉ�������")]
    public  AudioClip sound;
  
    private bool loopFlag = true;

    private MeshRenderer mesh;

    private bool foundFlag = false;
   // private float countTime = 0.0f;

    [Header("���Ăق����G���Z�b�g")]
    public GameObject[] enemy;
  
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }
    // Update is called once per frame
    void Update()
    {


        
 

    }

    //���񂾏u�Ԃɉ�����悤�ɂ��Ă��邽�߁A���ɉ������Ă����Ԃł���𓥂�ł���ƁA
    //��I������ՍĂщ����Ȃ�Ȃ��̂ŉ��C����K�v����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            audioSource.clip = sound;
            audioSource.Play();
            audioSource.loop = true;
            //Alert.instance.OnAleart(sound,loopFlag);
            Alert.instance.CallEnemy(enemy, transform);
            //foundFlag = true;            

            // Alert.instance.OnAleart();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        audioSource.clip = sound;
    //        audioSource.Play();
    //        audioSource.loop = true;
    //        //  Alert.instance.OnAleart(sound,loopFlag);
    //        Alert.instance.CallEnemy(enemy, transform);

    //    }


    //}


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            audioSource.Stop();
            //countTime = 0.0f;
            foundFlag = false;
            Alert.instance.ReleaseEnemy();
            //Alert.instance.ReleaseAleart();
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

    //void OnCollisionEnter(Collision other)//  �n�ʂɐG�ꂽ���̏���
    //{
    //    if (other.gameObject.tag=="Player")
    //    {
    //        audioSource.clip = sound;
    //        audioSource.Play();
           
    //        foundFlag = true;
    //    }
       
    //}
}

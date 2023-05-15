using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightSensing : MonoBehaviour
{
    private AudioSource audioSource;
    //[Header("�ʂɉ����w�肵�����Ȃ炢���")]
    [Header("����͌ʂɖ炷�悤�ɂ��Ă���̂ŉ����w�肵��")]
    [Header("AudioSource�̕���Loop�Ƀ`�F�b�N����Ă�������")]
    public  AudioClip sound;

    private MeshRenderer mesh;

    private bool foundFlag = false;
   // private float countTime = 0.0f;

    [Header("���Ăق����G���Z�b�g")]
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
        //�������Ă���Ȃ���Ă��鎞�Ԃ̃J�E���g���n�߂�   
        //if (foundFlag)
        //{
        //    countTime += Time.deltaTime;
        //    // FlushController.instance.flush();
            
        //}
      
           

       
        //Debug.Log(foundFlag);

    }

    //���񂾏u�Ԃɉ�����悤�ɂ��Ă��邽�߁A���ɉ������Ă����Ԃł���𓥂�ł���ƁA
    //��I������ՍĂщ����Ȃ�Ȃ��̂ŉ��C����K�v����
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

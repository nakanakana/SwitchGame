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
        //�ЂƂ܂���莞�ԂŖ�~�ނ悤�ɂ��Ă���B
        if (countTime >= 7)
        {
            foundFlag = false;
            countTime = 0.0f;
            Alert.instance.ReleaseAleart();
            // FlushController.instance.flushClear();
            // audioSource.Stop();
        }
        //�������Ă���Ȃ���Ă��鎞�Ԃ̃J�E���g���n�߂�   
        if (foundFlag)
        {
            countTime += Time.deltaTime;
            // FlushController.instance.flush();
          
        }
      
           

       
        //Debug.Log(foundFlag);

    }

    //���񂾏u�Ԃɉ�����悤�ɂ��Ă��邽�߁A���ɉ������Ă����Ԃł���𓥂�ł���ƁA
    //��I������ՍĂщ����Ȃ�Ȃ��̂ŉ��C����K�v����
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

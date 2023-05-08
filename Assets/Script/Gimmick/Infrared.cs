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
    [Header("���Ăق����G���Z�b�g")]
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

        //���[�U�[�ƃv���C���[�̔���
        //������Όx�񂪖�A���[�U�[���v���C���[�ŎՂ���
        //���Ɍ������Ă���΂Ȃɂ����Ȃ�
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lr.SetPosition(1, hit.point);


            if (hit.transform.CompareTag("Player") && !Alert.instance.GetisAlert())
            {
                //print("�N���Ҕ���");
                // �x�񉹂�炷�B
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

        //�ЂƂ܂���莞�ԂŖ�~�ނ悤�ɂ��Ă���B
        if (countTime >= 7)
        {
            foundFlag = false;
            countTime = 0.0f;
            //FlushController.instance.flushClear();
            Alert.instance.ReleaseAleart();
            // audioSource.Stop();
        }


        //�������Ă���Ȃ���Ă��鎞�Ԃ̃J�E���g���n�߂�    
        if (foundFlag)
        {
            countTime += Time.deltaTime;
            // FlushController.instance.flush();
            
        }

       

    }
}

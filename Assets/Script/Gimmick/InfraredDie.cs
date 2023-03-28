using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InfraredDie : MonoBehaviour
{
    public AudioClip sound;
    public float maxDistance = 50f;
    private LineRenderer lr;
    private AudioSource audioSource;
    private bool foundFlag = false;
    private float countTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        lr.SetPosition(0, ray.origin);
        Debug.Log(foundFlag);
        // Debug.Log(countTime);
        //���[�U�[�ƃv���C���[�̔���
        //������΃��[�U�[���v���C���[�ŎՂ��A�v���C���[�͎��ʁB���߂̌��Ђ��Ȃ��B
        //�������Ă��Ȃ���΂��̌����������Ȃ��Ƃ炷
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lr.SetPosition(1, hit.point);


            if (hit.transform.CompareTag("Player") && !foundFlag)
            {
             
                SceneManager.LoadScene("SampleScene");
               
            }
        }
        else
        {
            lr.SetPosition(1, ray.origin + ray.direction * maxDistance);

        }

       
    }
}


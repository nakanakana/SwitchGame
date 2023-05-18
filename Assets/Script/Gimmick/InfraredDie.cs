using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InfraredDie : MonoBehaviour
{
    //public AudioClip sound;
    public float maxDistance = 50f;
    private LineRenderer lr;
    private AudioSource audioSource;
    private bool foundFlag = false;

    [Header("�v���C���[���Z�b�g")]
    public GameObject player;

    private MoveControl moveControl;
    // private float countTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
        moveControl = player.GetComponent<MoveControl>();
    }

    // Update is called once per frame
    void Update()
    {
       

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        lr.SetPosition(0, ray.origin);
        int layerMask = 1 << 2 | 1 << 8 | 1 << 10;
        layerMask = ~layerMask;
        //Debug.Log(foundFlag);
        // Debug.Log(countTime);
        //���[�U�[�ƃv���C���[�̔���
        //������΃��[�U�[���v���C���[�ŎՂ��A�v���C���[�͎��ʁB���߂̌��Ђ��Ȃ��B
        //�������Ă��Ȃ���΂��̌����������Ȃ��Ƃ炷
        if (Physics.Raycast(ray, out hit, maxDistance,layerMask))
        {
            lr.SetPosition(1, hit.point);
 
            if (hit.transform.CompareTag("Player") && !foundFlag)
            {
                moveControl.OnDead();
               // lr.SetPosition(1, ray.origin + ray.direction * maxDistance);
            }
        }
        else
        {          
           lr.SetPosition(1, ray.origin + ray.direction * maxDistance);

        }
       // Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.blue);

    }
}


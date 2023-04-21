using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�e�̔��ˏꏊ")]
    private GameObject firingpoint;

    [SerializeField]
    [Tooltip("�e")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("�e�̑���")]
    private float speed = 30.0f;

    //int count;

    float DelayTimer = 5.0f;

    private void Start()
    {
        //count = 0;
        DelayTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        DelayTimer -= Time.deltaTime;
        if (DelayTimer <= 3.0f)
        {
            //���N���b�N������
            if (Input.GetMouseButtonDown(0))
            {
                //if (count < 5)
                {
                    //�e�𔭎˂���
                    Shot();

                    DelayTimer = 5.0f;
                    //count++;
                    //Debug.Log(count);
                }

            }
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    count = 0;
        //    Debug.Log("Reload now");
        //}


    }

    ///<summary>
    ///�e�̔���
    ///</summary>
    private void Shot()
    {
        //�e�̔��ˈʒu���擾
        Vector3 bulletPosition = firingpoint.transform.position;

        //bulletPosition�Ŏ擾�����ꏊ�ɁA"Bullet"��Prefab���o��������
        GameObject newBall = Instantiate(bullet, bulletPosition, transform.rotation);

        // �o���������{�[����forward(z������)
        //Vector3 direction = newBall.transform.forward;
        // �e�̔��˕�����newBall��z����(���[�J�����W)�����A�e�I�u�W�F�N�g��rigidbody�ɏՌ��͂�������
        //newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // �o���������{�[���̖��O��"bullet"�ɕύX
        newBall.name = bullet.name;
        // �o���������{�[����0.1�b��ɏ���
        Destroy(newBall, 0.1f);

    }

 

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent�g���Ƃ��ɕK�v
using UnityEngine.AI;
using UnityEditor;
using UnityEngine.SceneManagement;

//�I�u�W�F�N�g��NavMeshAgent�R���|�[�l���g��ݒu
[RequireComponent(typeof(NavMeshAgent))]

public class Patrol : MonoBehaviour
{
    public static Patrol instance;
    private Animator animator;
    public Transform[] points;
    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;
    Vector3 playerPos;
    GameObject player;
    float distance;
    [SerializeField] float trackingRange = 3f;
    [SerializeField] float quitRange = 5f;
    public bool tracking = false;
    [SerializeField]
    private float searchAngle = 100f;
    [SerializeField] GameObject ball;
    private float ballSpeed = 10.0f;
    private float time = 1.0f;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // autoBraking �𖳌��ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ����܂�
        //(�܂�A�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă�
        // ���x�����Ƃ��܂���)
        agent.autoBraking = true;

        GotoNextPoint();

        //�ǐՂ������I�u�W�F�N�g�̖��O������
        //player = GameObject.Find("Player");
        player = GameObject.FindWithTag("Player");
    }
    

    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ��܂�
        if (points.Length == 0)
            return;

        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ肵�܂�
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ肵�A
        // �K�v�Ȃ�Ώo���n�_�ɂ��ǂ�܂�
        destPoint = (destPoint + 1) % points.Length;
        
    }


    void Update()
    {
        //Player�Ƃ��̃I�u�W�F�N�g�̋����𑪂�
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);
        //�@��l���̕���
        var playerDirection = player.transform.position - transform.position;
        //�@�G�̑O������̎�l���̕���
        var angle = Vector3.Angle(transform.forward, playerDirection);

        if (tracking && angle <= searchAngle)
        {
            //�ǐՂ̎��AquitRange��苗�������ꂽ�璆�~
            if (distance > quitRange)
            {
                tracking = false;
                
            }

            //Player��ڕW�Ƃ���
            agent.destination = playerPos;
            EnemyShot();
        }
        else
        {
            //Player��trackingRange���߂Â�����ǐՊJ�n
            if (distance < trackingRange && angle <= searchAngle)
            {
                EnemyShot();
                tracking = true;
            }

            // �G�[�W�F���g�����ڕW�n�_�ɋ߂Â��Ă�����A
            // ���̖ڕW�n�_��I�����܂�
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        if (tracking) { 
            
            Debug.Log("�v���C���[������");
        }

    }
    public void AlertCome(Transform alertpos)
    {
        agent.destination = alertpos.position;
        if (distance < trackingRange)
            tracking = true;
        if (agent.destination == alertpos.position && tracking == false) { GotoNextPoint(); }
    }
    void OnDrawGizmosSelected()
    {
        //trackingRange�͈̔͂�Ԃ����C���[�t���[���Ŏ���
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRange�͈̔͂�����C���[�t���[���Ŏ���
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);

    }
    private void OnDrawGizmos()
    {
        Handles.color = new Color(1f, 0, 0, 0.2f);
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, trackingRange);
    }
    void EnemyShot()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            BallShot();
            time = 1.0f;
        }
    }

    void BallShot()
    {
        GameObject shotObj = Instantiate(ball, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        Destroy(shotObj, 2.0f);
    }
}
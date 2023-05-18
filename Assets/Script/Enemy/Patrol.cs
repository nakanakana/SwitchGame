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

    [SerializeField] float ShotPosY = 0;

    [Header("�M�Y���Ɋ��蓖�Ă�}�e���A��")]
    [SerializeField] private Material mat;
    private GameObject _gizmo;
    private FanGizmos.FanGizmo _fanGizmo;

    // �A�j���[�^�[�̃p�����[�^�[��ID���擾�i�������̂��߁j
    readonly int SpeedHash = Animator.StringToHash("Speed");
    //readonly int AttackHash = Animator.StringToHash("Attack");
    readonly int DeadHash = Animator.StringToHash("Dead");

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

        _fanGizmo = new FanGizmos.FanGizmo();
        _gizmo = _fanGizmo.CreateGizmo(this.gameObject, Vector3.zero, agent.transform.eulerAngles, mat);
    }
    

    void GotoNextPoint()
    {
        // �n�_���Ȃɂ��ݒ肳��Ă��Ȃ��Ƃ��ɕԂ��܂�
        if (points.Length == 0)
        {
            //animator.SetFloat("speed", 0);
            return;
        }
        //animator.SetFloat("speed", 2);
        // �G�[�W�F���g�����ݐݒ肳�ꂽ�ڕW�n�_�ɍs���悤�ɐݒ肵�܂�
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ肵�A
        // �K�v�Ȃ�Ώo���n�_�ɂ��ǂ�܂�
        destPoint = (destPoint + 1) % points.Length;

        agent.speed = 2.5f;
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
            agent.speed = 4.0f;
            animator.SetBool("Attack", true);
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
            {
                GotoNextPoint();
            }
            animator.SetBool("Attack", false);
        }

        UpdateAnimator();
        _fanGizmo.RefreshGizmo(ref _gizmo, this.gameObject, searchAngle*2, trackingRange);
    }
    public void AlertCome(Transform alertpos)
    {
        agent.destination = alertpos.position;
        agent.speed = 3.0f;
        if (distance < trackingRange)
            tracking = true;
        if (agent.destination == alertpos.position && tracking == false) { GotoNextPoint(); }
    }

    public void Return()
    {
        if (distance < trackingRange)
            tracking = true;
        if (tracking == false) GotoNextPoint();
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

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = new Color(1f, 0, 0, 0.2f);
        Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -searchAngle, 0f) * transform.forward, searchAngle * 2f, trackingRange);
    }
#endif

    void EnemyShot()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            BallShot();
            time = 1.0f;
        
        }
        animator.SetBool("Attack", true);
    }

    void BallShot()
    {
        Vector3 traformPos = transform.position;
        traformPos.y += ShotPosY;
        GameObject shotObj = Instantiate(ball, traformPos, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        Destroy(shotObj, 2.0f);
    }

    // �A�j���[�^�[�̃A�b�v�f�[�g����
    void UpdateAnimator()
    {
        animator.SetFloat(SpeedHash, agent.desiredVelocity.magnitude);
    }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;
using UnityEditor;
using UnityEngine.SceneManagement;

//オブジェクトにNavMeshAgentコンポーネントを設置
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
    //[SerializeField] float trackingRange = 3f;
    
    public bool tracking = false;
    //[SerializeField]
    //private float searchAngle = 100f;

    [Header("索敵範囲の長さ")]
    [SerializeField, Range(0, 50)] private float _sight_range;
    [Header("索敵範囲の角度")]
    [SerializeField, Range(0, 180)] private float _sight_angle;
    [Header("索敵範囲に割り当てるマテリアル")]
    [SerializeField] private Material mat;

    [Header("見失う範囲の長さ")]
    [SerializeField, Range(0, 60)] float quitRange;
    [Header("見失う範囲の角度")]
    [SerializeField, Range(0, 360)] float quitAngle;
    [SerializeField] private Material mat2;

    [SerializeField] GameObject ball;
    private float ballSpeed = 10.0f;
    private float time = 1.0f;

    [SerializeField] float ShotPosY = 0;

    
    private GameObject _gizmo1;
    private FanGizmos.FanGizmo _fanGizmo1;
    private GameObject _gizmo2;
    private FanGizmos.FanGizmo _fanGizmo2;

    Ray ray;
    RaycastHit hit;
    Vector3 direction;   // Rayを飛ばす方向
    // アニメーターのパラメーターのIDを取得（高速化のため）
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
        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = true;

        GotoNextPoint();
        
        //追跡したいオブジェクトの名前を入れる
        //player = GameObject.Find("Player");
        player = GameObject.FindWithTag("Player");

        _fanGizmo1 = new FanGizmos.FanGizmo();
        _gizmo1 = _fanGizmo1.CreateGizmo(this.gameObject, Vector3.zero, agent.transform.eulerAngles, mat);
        _fanGizmo2 = new FanGizmos.FanGizmo();
        _gizmo2 = _fanGizmo2.CreateGizmo(this.gameObject, Vector3.zero, agent.transform.eulerAngles, mat2);
    }
    

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
        {
            //animator.SetFloat("speed", 0);
            return;
        }

        if (!MoveControl.instance.hitEnemy)
        {
            //animator.SetFloat("speed", 2);
            // エージェントが現在設定された目標地点に行くように設定します
            agent.destination = points[destPoint].position;

            // 配列内の次の位置を目標地点に設定し、
            // 必要ならば出発地点にもどります
            destPoint = (destPoint + 1) % points.Length;

            agent.speed = 3.0f;
        }
    }


    void Update()
    {
        UpdateAnimator();
        //_fanGizmo1.RefreshGizmo(ref _gizmo1, this.gameObject, searchAngle * 2, trackingRange);
        _fanGizmo2.RefreshGizmo(ref _gizmo1, gameObject, _sight_angle, _sight_range);
        _fanGizmo2.RefreshGizmo(ref _gizmo2, gameObject, quitAngle, quitRange);

        if (MoveControl.instance.hitEnemy)
        {
            GotoNextPoint();
            tracking=false;
            animator.SetBool("Attack", false);
            agent.speed = 0;
            return;
        }
        
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);
        //　主人公の方向
        var playerDirection = player.transform.position - transform.position;
        //　敵の前方からの主人公の方向
        var angle = Vector3.Angle(transform.forward, playerDirection);

        // Rayを飛ばす方向を計算
        Vector3 temp = playerPos - transform.position;
        direction = temp.normalized;
        ray = new Ray(transform.position, direction);  // Rayを飛ばす
        //Debug.DrawRay(ray.origin, ray.direction * _sight_range, Color.black);  // Rayをシーン上に描画

        if (Physics.Raycast(ray.origin, ray.direction * _sight_range, out hit))
        {
            if (/*hit.collider.CompareTag("Player") && */!MoveControl.instance.hitEnemy && angle <= _sight_angle && distance < _sight_range)
            {
                tracking = true;

            }
            else tracking = false;
        }

        if (tracking)
        {
            

            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange || angle > quitAngle || MoveControl.instance.hitEnemy)
            {
                tracking = false;
            }

            //Playerを目標とする
            agent.destination = playerPos;
            EnemyShot();
            agent.speed = 5.0f;
            animator.SetBool("Attack", true);

        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (Physics.Raycast(ray.origin, ray.direction * _sight_range, out hit))
            {
                if (/*hit.collider.CompareTag("Player") && */!MoveControl.instance.hitEnemy && angle <= _sight_angle && distance < _sight_range)
                {
                    tracking = true;

                }
                else tracking = false;
            }

            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
            animator.SetBool("Attack", false);
        }

        if (!tracking) GotoNextPoint();

       
    }
    public void AlertCome(Transform alertpos)
    {
        agent.destination = alertpos.position;
        agent.speed = 4.0f;
        if (distance < _sight_range)
            tracking = true;
        if (agent.destination == alertpos.position && tracking == false) { GotoNextPoint(); }
    }

    public void Return()
    {
        if (distance < _sight_range)
            tracking = true;
        if (!tracking) GotoNextPoint();
    }

    void OnDrawGizmosSelected()
    {
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
        //Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, quitRange);

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //Handles.color = new Color(1f, 0, 0, 0.2f);
        //Handles.DrawSolidArc(transform.position, Vector3.up, Quaternion.Euler(0f, -_sight_angle, 0f) * transform.forward, _sight_angle, _sight_range);
    }
#endif

    void EnemyShot()
    {
        if (!MoveControl.instance.hitEnemy)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                BallShot();
                time = 1.0f;

            }
            animator.SetBool("Attack", true);
        }
    }

    void BallShot()
    {
        Vector3 traformPos = transform.position;
        traformPos.y += ShotPosY;
        GameObject shotObj = Instantiate(ball, traformPos, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        Destroy(shotObj, 2.0f);
    }

    // アニメーターのアップデート処理
    void UpdateAnimator()
    {
        animator.SetFloat(SpeedHash, agent.desiredVelocity.magnitude);
    }
    
}
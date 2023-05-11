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
        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        agent.autoBraking = true;

        GotoNextPoint();

        //追跡したいオブジェクトの名前を入れる
        //player = GameObject.Find("Player");
        player = GameObject.FindWithTag("Player");
    }
    

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
        
    }


    void Update()
    {
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);
        //　主人公の方向
        var playerDirection = player.transform.position - transform.position;
        //　敵の前方からの主人公の方向
        var angle = Vector3.Angle(transform.forward, playerDirection);

        if (tracking && angle <= searchAngle)
        {
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
            {
                tracking = false;
                
            }

            //Playerを目標とする
            agent.destination = playerPos;
            EnemyShot();
        }
        else
        {
            //PlayerがtrackingRangeより近づいたら追跡開始
            if (distance < trackingRange && angle <= searchAngle)
            {
                EnemyShot();
                tracking = true;
            }

            // エージェントが現目標地点に近づいてきたら、
            // 次の目標地点を選択します
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        if (tracking) { 
            
            Debug.Log("プレイヤーがおる");
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
        //trackingRangeの範囲を赤いワイヤーフレームで示す
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, trackingRange);

        //quitRangeの範囲を青いワイヤーフレームで示す
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
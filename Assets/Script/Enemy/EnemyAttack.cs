using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;
    private float ballSpeed = 10.0f;
    private float time = 1.0f;
    //bool PhitFlag = false;
    public static EnemyAttack instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    //void Update()
    //{
        //if (Patrol.instance.tracking)
        //{
        //    //transform.LookAt(player.transform);
        //    time -= Time.deltaTime;
        //    if (time <= 0)
        //    {
        //        BallShot();
        //        time = 1.0f;
        //    }
        //}
    //}

    public void EnemyShot()
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

    //public bool PlayerHit()
    //{
    //    if (ball.transform.position == player.transform.position) PhitFlag = true;
    //    return PhitFlag;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject damageeffect;
    private RaycastHit hit;
    private EnemyStatus status;
    private Attack at;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();
        at = GetComponent<Attack>();
    }

    void Update()
    {

        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);

        //  transform.position += transform.forward * this.speed;


        // rigid.MovePosition(transform.position + transform.forward * Time.deltaTime);
        // transform.rotation = Quaternion.LookRotation(transform.position - SlimePos);

        //  SlimePos = transform.position;
        //transform.rotation = Quaternion.LookRotation(new Vector3(0, 90, 0));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!status.IsMove)//Normalじゃない
            {
                if (!status.IsDie)
                {
                    agent.isStopped = true;
                    return;
                }
            }

            GameObject Target = GameObject.Find("SDunitychan");

            var diff = Target.transform.position - transform.position;//座標差
            var distance = diff.magnitude;//プレイヤーとの距離
            var direction = diff.normalized;//ベクトルの長さ

            if (distance < 1.0f)
            {
                at.CheckAttack();
            }

            if (Physics.Raycast(transform.position, direction, out hit, distance))
            {
                if (hit.transform.gameObject == Target)
                {
                    if (!status.IsDie)
                    {
                        agent.isStopped = false;
                        agent.destination = Target.transform.position;
                    }
                }
                else
                {
                    if (!status.IsDie)
                    {
                        agent.isStopped = true;
                    }
                }

            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

            foreach (ContactPoint point in other.contacts)
            {
                GameObject effect = Instantiate(damageeffect) as GameObject;
                effect.transform.position = (Vector3)point.point;

            }

        }
    }

}
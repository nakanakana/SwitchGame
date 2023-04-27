//Add0427
using System.Collections;
using System.Collections.Generic;
///

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class TargetNavigation : MonoBehaviour
{
	[SerializeField]
	private Transform m_Target;

	private NavMeshAgent m_Agent;

	//Add0427
	private NavMeshAgent agent;
	public GameObject damageeffect;
	private RaycastHit hit;
	private EnemyStatus status;
	private Attack at;
	/// 

	void Start()
	{
		m_Agent = GetComponent<NavMeshAgent>();

		//Add0427
		agent = GetComponent<NavMeshAgent>();
		status = GetComponent<EnemyStatus>();
		at = GetComponent<Attack>();
	}

	void Update()
	{
		m_Agent.SetDestination(m_Target.position);

	}

    //Add0427
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

            GameObject Target = GameObject.Find("Player");

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatus : Statusmanager
{
    private NavMeshAgent agent;
    private MoveEnemy sc;

    protected override void Start()
    {
        base.Start();
        sc = GetComponent<MoveEnemy>();
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
       // animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
    }
    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);

    }


}

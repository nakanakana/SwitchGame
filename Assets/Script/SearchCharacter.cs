using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private MoveEnemy moveEnemy;
    [SerializeField]
    private SphereCollider searchArea;
    [SerializeField]
    private float searchAngle = 100f;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject ball;
    private float ballSpeed = 10.0f;
    private float time = 1.0f;

    private Animator animator;

    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            //�@��l���̕���
            var playerDirection = col.transform.position - transform.position;
            //�@�G�̑O������̎�l���̕���
            var angle = Vector3.Angle(transform.forward, playerDirection);
            //�@�T�[�`����p�x���������甭��
            if (angle <= searchAngle)
            {
                Debug.Log("��l������: " + angle);
                moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);

                transform.LookAt(Player.transform);
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    BallShot();
                    time = 1.0f;
                }
            }

        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("������");
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }

    void BallShot()
    {
        GameObject shotObj = Instantiate(ball, transform.position, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
        Destroy(shotObj, 0.8f);
    }

}

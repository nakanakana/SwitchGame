using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHP;
    private CapsuleCollider CapCol;
    private Animator animator;
    private Rigidbody rigitbody;
    [SerializeField] GameObject unitychan;

    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan_dynamic");
        //enemyHP = 2;
        CapCol = this.GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        rigitbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP < 1)
        {
            unitychan.GetComponent<Patrol>().enabled = false;
            CapCol.enabled = false;
            rigitbody.velocity = Vector3.zero;
            rigitbody.angularVelocity = Vector3.zero;
            animator.SetBool("Run", false);
            animator.SetTrigger("Dead");
        }
        else animator.SetBool("Run", true);
    }

    /// <summary>
    /// GameOverAreaにこのスクリプトがついているオブジェクトが触れたら
    /// 触れたオブジェクトをすぐに消す
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GameOverArea") //他のオブジェクトがGameOverAreaに触れたら
        {
            //Destroy
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("No Hit");

        if (collision.gameObject.CompareTag("Bullet") && gameObject.CompareTag("Enemy"))
        {

            // 0.2秒後にEnemy消える
            //Destroy(gameObject, 0.2f);
            enemyHP -= 1;
            
            //弾消える
            Destroy(collision.gameObject);
        }
        

    }
}

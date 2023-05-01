using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitSword : MonoBehaviour
{
    private CapsuleCollider CapCol;
    //private GameObject[] enemyBox;

    float DelayTimer = 5.0f;

    //Start is called before the first frame update
    void Start()
    {
        CapCol = GetComponent<CapsuleCollider>();

        DelayTimer = 5.0f;

        CapCol.enabled = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CapCol.enabled = true;

            if (CapCol.enabled == true)
            {
                Debug.Log("TRUE");

            }

        }
        else
        {
            CapCol.enabled = false;

            if (CapCol.enabled == false)
                Debug.Log("FALSE");

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // 剣で当たったオブジェクトが敵である場合
        if (collision.gameObject.tag == "Enemy")
        {
            // 敵を削除する
            Destroy(collision.gameObject, 0.2f);

        
            if (SceneManager.GetActiveScene().name == "stage1")
            {
                EnemyCount.instance.SubEnemyCount();
               
            }

            if (SceneManager.GetActiveScene().name == "stage2")
            {
                EnemyCount2.instance.SubEnemyCount();
            }
        }

    }

    //public float attackspan = 0.5f;
    //public Collider attackCollider;
    //private Statusmanager status;

    //// Start is called before the first frame update
    //private void Start()
    //{
    //    status = GetComponent<Statusmanager>();
    //    attackCollider.enabled = false;

    //}
    //private void Update()
    //{

    //}
    //public void CheckAttack()
    //{
    //    if (!status.IsAttack) return;

    //    status.GoToAttack();
    //}

    //public void AttackStart()//当たり判定用コライダを発動
    //{
    //    attackCollider.enabled = true;
    //}

    //public void HitObject(Collider collider)
    //{
    //    var obj = collider.GetComponent<Statusmanager>();
    //    if (obj == null) return;
    //    obj.Damage(1);
    //}

    //public void AttackEnd()//当たり判定用コライダを非表示する
    //{
    //    x
    //    attackCollider.enabled = false;
    //    StartCoroutine(Attackspan());
    //}
    //private IEnumerator Attackspan()
    //{
    //    yield return new WaitForSeconds(attackspan);
    //    status.GoToNormal();
    //}

}

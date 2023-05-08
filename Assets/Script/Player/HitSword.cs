using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitSword : MonoBehaviour
{
    //private Transform animationTransform;
    //private BoxCollider BoxCol;
    //private CapsuleCollider CapCol;
    //private GameObject[] enemyBox;

    //float DelayTimer = 5.0f;

    //Start is called before the first frame update
    //void Start()
    //{
    //    //animationTransform = GetComponent<Transform>();
    //    //BoxCol = GetComponent<BoxCollider>();
    //    CapCol = GetComponent<CapsuleCollider>();

    //    //DelayTimer = 5.0f;

    //    //BoxCol.enabled = false;
    //    CapCol.enabled = false;
    //}

    //void Update()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //BoxCol.enabled = true;
    //        //CapCol.enabled = true;

    //        if (/*BoxCol.enabled == true*/CapCol.enabled == true)
    //        {
    //            Debug.Log("TRUE");
    //        }

    //        Debug.Log("マウス押下");


    //    }
    //    else if(Input.GetMouseButtonUp(0))
    //    {
    //        //BoxCol.enabled = false;
    //        CapCol.enabled = false;

    //        Debug.Log("マウス押上");

    //        if (/*BoxCol.enabled == true*/CapCol.enabled == false)
    //        {
    //            Debug.Log("FALSE");
    //        }


    //    }
    //    // AnimationのTransformに合わせてBoxColliderの位置を同期する
    //    //BoxCol.center = animationTransform.position;
    //    //Debug.Log(BoxCol.enabled);
    //}

    //void OnCollisionEnter(Collision collision)
    //{

    //    //if (BoxCol.enabled == true)
    //    //{
    //        // 剣で当たったオブジェクトが敵である場合
    //        if (collision.gameObject.tag == "Enemy")
    //        {
    //            // 敵を削除する
    //            Destroy(collision.gameObject, 0.5f);


    //            //if (SceneManager.GetActiveScene().name == "stage1")
    //            //{
    //            //    EnemyCount.instance.SubEnemyCount();

    //            //}

    //            //if (SceneManager.GetActiveScene().name == "stage2")
    //            //{
    //            //    EnemyCount2.instance.SubEnemyCount();
    //            //}
    //        }

    //   // }

    //}

    void OnTriggerEnter(Collider other)
    {

        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {

            Destroy(other.gameObject, 0.4f);

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

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

    //        Debug.Log("�}�E�X����");


    //    }
    //    else if(Input.GetMouseButtonUp(0))
    //    {
    //        //BoxCol.enabled = false;
    //        CapCol.enabled = false;

    //        Debug.Log("�}�E�X����");

    //        if (/*BoxCol.enabled == true*/CapCol.enabled == false)
    //        {
    //            Debug.Log("FALSE");
    //        }


    //    }
    //    // Animation��Transform�ɍ��킹��BoxCollider�̈ʒu�𓯊�����
    //    //BoxCol.center = animationTransform.position;
    //    //Debug.Log(BoxCol.enabled);
    //}

    //void OnCollisionEnter(Collision collision)
    //{

    //    //if (BoxCol.enabled == true)
    //    //{
    //        // ���œ��������I�u�W�F�N�g���G�ł���ꍇ
    //        if (collision.gameObject.tag == "Enemy")
    //        {
    //            // �G���폜����
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

        //�U���������肪Enemy�̏ꍇ
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

    //public void AttackStart()//�����蔻��p�R���C�_�𔭓�
    //{
    //    attackCollider.enabled = true;
    //}

    //public void HitObject(Collider collider)
    //{
    //    var obj = collider.GetComponent<Statusmanager>();
    //    if (obj == null) return;
    //    obj.Damage(1);
    //}

    //public void AttackEnd()//�����蔻��p�R���C�_���\������
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

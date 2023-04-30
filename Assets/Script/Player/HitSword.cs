using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSword : MonoBehaviour
{
    private CapsuleCollider CapCol;
    private GameObject[] enemyBox;

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
        // ���œ��������I�u�W�F�N�g���G�ł���ꍇ
        if (collision.gameObject.tag == "Enemy")
        {
            // �G���폜����
            Destroy(collision.gameObject, 0.2f);

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
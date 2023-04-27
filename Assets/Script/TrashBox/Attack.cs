using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackspan = 0.5f;
    public Collider attackCollider;
    private Statusmanager status;

    // Start is called before the first frame update
    private void Start()
    {
        status = GetComponent<Statusmanager>();
        attackCollider.enabled = false;

    }
    private void Update()
    {

    }
    public void CheckAttack()
    {
        if (!status.IsAttack) return;

        status.GoToAttack();
    }

    public void AttackStart()//当たり判定用コライダを発動
    {
        attackCollider.enabled = true;
    }

    public void HitObject(Collider collider)
    {
        var obj = collider.GetComponent<Statusmanager>();
        if (obj == null) return;
        obj.Damage(1);
    }

    public void AttackEnd()//当たり判定用コライダを非表示する
    {
        attackCollider.enabled = false;
        StartCoroutine(Attackspan());
    }
    private IEnumerator Attackspan()
    {
        yield return new WaitForSeconds(attackspan);
        status.GoToNormal();
    }

}
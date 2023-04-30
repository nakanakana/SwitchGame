using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Statusmanager : MonoBehaviour
{
    protected enum State
    {
        Normal,
        Attack,
        Die
    }

    public bool IsMove => State.Normal == state;
    public bool IsAttack => State.Normal == state;
    public bool IsDie => State.Die == state;
    protected Animator animator;
    protected State state = State.Normal;

    [SerializeField] private int Maxlife;
    [SerializeField] private int life;

    protected virtual void Start()
    {
        life = Maxlife;

        animator = GetComponentInChildren<Animator>();

    }

    public void GoToAttack()
    {
        if (!IsAttack) return;//Attack‚È‚çreturn

        state = State.Attack;
        animator.SetTrigger("IsAttacked");
        Debug.Log("Attack");
    }
    public void GoToNormal()
    {
        state = State.Normal;

    }
    public int Life()
    {
        return life;
    }
    public void Damage(int damage)
    {
        if (state == State.Die) return;

        life -= damage;
        if (life > 0) return;

        state = State.Die;
        animator.SetTrigger("Die");
        Debug.Log("Die");
        Die();
    }
    protected virtual void Die()
    {

    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : ICommand
{
    Animator m_Animator;
    int counter=0;
    public SwordAttack(Animator animator){
        this.m_Animator=animator;
    }
    public void Execute()
    {
        m_Animator.SetTrigger("AttackTrigger");
        m_Animator.SetInteger("Counter",counter++);
        if(counter>10)counter=0;
        Debug.Log(counter);
    }

    public void Exit()
    {
        m_Animator.ResetTrigger("AttackTrigger");
        //m_Animator.SetInteger("Counter",counter);
    }
}

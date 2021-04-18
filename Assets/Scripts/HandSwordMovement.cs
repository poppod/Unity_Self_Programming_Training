using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSwordMovement : ICommand
{   
    Animator m_Animator;
    public HandSwordMovement(Animator animator){
        this.m_Animator=animator;
    }
    public void Execute()
    {
        m_Animator.SetBool("UseSword",true);
    }

    public void Exit()
    {
        m_Animator.SetBool("UseSword",false);
    }
}

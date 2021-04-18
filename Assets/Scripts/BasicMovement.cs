using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : ICommand
{
    Animator m_Animator;
    public BasicMovement(Animator animator){
        this.m_Animator=animator;
    }
    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}

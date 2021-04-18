using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class AttackEventManager 
{
    
    
    static SimpleAnimationEvent invoker1;
    static UnityAction<int> listener1;
    
    public static void AddInvoker(SimpleAnimationEvent ivk){
        invoker1=ivk;
        if(listener1!=null){
            invoker1.AddListener(listener1);
        }
    }
    public static void AddListenner(UnityAction<int> listener){
        listener1=listener;
        if(invoker1!=null){
            invoker1.AddListener(listener1);
        }
        
        Debug.Log("add listener");
        
        
    }
    // public void Invoke(int damage){
    //     if(onAttack!=null){
    //         onAttack.Invoke(damage);
    //         Debug.Log("Invoke");
    //     }
    // }
}

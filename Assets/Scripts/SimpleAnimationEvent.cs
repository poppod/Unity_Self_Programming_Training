using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SimpleAnimationEvent : MonoBehaviour
{
    
    public GameObject rightHand;
    public GameObject sword;
    public GameObject weaponInventory;
    EnemyTarget enemyTarget;
    GetDamageEvent onAttack = new GetDamageEvent() ;
    ColliderDetect swordCol;
    private void Start() {
        enemyTarget= GetComponent<EnemyTarget>();
        AttackEventManager.AddInvoker(this);
        swordCol=sword.GetComponent<ColliderDetect>();
    }
    // Start is called before the first frame update
    public void TakeSword(){
        // sword.transform.position=rightHand.transform.position;
        sword.transform.SetParent(rightHand.transform);
        sword.transform.localPosition=new Vector3(0.05f,0,0.5f);
        sword.transform.localRotation= Quaternion.Euler(0,175,0);

    }
    public void UntakeSword(){
        //sword.transform.position=weaponInventory.transform.position;
        sword.transform.SetParent(weaponInventory.transform);
        sword.transform.localRotation=Quaternion.Euler(-90,0,0);
        sword.transform.localPosition=Vector3.zero;
    }
    public void SwordAttack(int damage){
        
        Debug.Log("Attack :"+swordCol.detect);
        if(swordCol.detect){
            Debug.Log("Attack 2:"+swordCol.detect);
            onAttack.Invoke(damage);
        }
       // if(enemyTarget.enemy!=null){
        
        
    }
    public void AddListener(UnityAction<int> listener){
        onAttack.AddListener(listener);
    }
    
}

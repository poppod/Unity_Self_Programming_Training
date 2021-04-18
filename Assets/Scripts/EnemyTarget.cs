using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class EnemyTarget : MonoBehaviour
{
    //List<GameObject> enemyList;
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Enemy"){
            //enemyList.Add(other.gameObject);
            if(enemy==null){
                enemy=other.gameObject;
            }
            else{
               
                if( Vector3.Distance(enemy.gameObject.transform.position,transform.position)>
                    Vector3.Distance(other.gameObject.transform.position,transform.position)
                ){
                    enemy=other.gameObject;
                }
            }
            Debug.Log("Found Enemy");
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag=="Enemy"){
            if(enemy!=null){
                if( Vector3.Distance(enemy.gameObject.transform.position,transform.position)>
                    Vector3.Distance(other.gameObject.transform.position,transform.position)
                ){
                    enemy=other.gameObject;
                }
            }
            else{
                enemy=other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Enemy"){
             
            enemy=null;
            Debug.Log("Lost Enemy");
        }
    }
    
}

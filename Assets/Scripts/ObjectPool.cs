using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Queue<GameObject> m_Qobjects=new Queue<GameObject>();
    GameObject prefab;
    public ObjectPool(GameObject obj){
        this.prefab=obj;
        InitObect();
    }
    public ObjectPool(GameObject obj,int count){
        this.prefab=obj;
        InitObect(count);
    }
    void InitObect(int count =5){
        for(int i=0;i<count;i++){
            GameObject newObj= Instantiate(this.prefab,Vector3.zero,Quaternion.identity);
            newObj.SetActive(false);
            m_Qobjects.Enqueue(newObj);
        }
        
    }
    public GameObject GetObject(){
        if(m_Qobjects.Count<=0){
            InitObect(1);
        }
        GameObject obj=m_Qobjects.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    public void ThrowToPool(GameObject obj){
        obj.SetActive(false);
        m_Qobjects.Enqueue(obj);
    }
    
}

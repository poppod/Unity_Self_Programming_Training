using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
public class PopUpDamageUI : MonoBehaviour
{
    [SerializeField]
    GameObject damageUIPrefab;
    ObjectPool poppupDamagePool;
    EnemyTarget enemyTarget;
    
    // Start is called before the first frame update
    private void Awake() {
        
    }
    void Start()
    {
        poppupDamagePool=new ObjectPool(damageUIPrefab);
        enemyTarget= GetComponent<EnemyTarget>();
        AttackEventManager.AddListenner(GetDamage);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PopUpDamageAnimation(RectTransform prefab){
        if(prefab!=null && enemyTarget.enemy!=null){
            prefab.transform.position=enemyTarget.enemy.transform.localPosition;
            Vector3 toPos= new Vector3();
            toPos=prefab.transform.position;
            toPos.y+=2.5f;
            LeanTween.move(prefab.gameObject,toPos,1f).setEaseOutCubic();
            
            
        }
        else{
            poppupDamagePool.ThrowToPool(prefab.gameObject);
        }
        yield return new WaitForSeconds(1.5f);
        poppupDamagePool.ThrowToPool(prefab.gameObject);
    }
     void GetDamage(int damage){
        GameObject poppup= poppupDamagePool.GetObject();
        poppup.GetComponentInChildren<TextMeshPro>().text="-"+damage.ToString();//damage.ToString();
        
        StartCoroutine(PopUpDamageAnimation(poppup.GetComponentInChildren<RectTransform>()));
        Debug.Log("Get damage(10)");
        
    }
    
}

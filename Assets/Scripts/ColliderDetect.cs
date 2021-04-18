using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetect : MonoBehaviour
{
    Collider m_col;
    public bool detect=false;
    // Start is called before the first frame update
    void Start()
    {
        m_col=GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // private void OnCollisionEnter(Collision other) {
    //     StopAllCoroutines();
    //     detect=true;
    // }
    // private void OnCollisionExit(Collision other) {
    //     StartCoroutine(DelayExit());
    // }    
    private void OnTriggerEnter(Collider other) {
        StopAllCoroutines();
        detect=true;
    }
    private void OnTriggerExit(Collider other) {
        StartCoroutine(DelayExit());
    }
    IEnumerator DelayExit(){
        yield return new WaitForSeconds(1f);
        detect=false;
    }
}

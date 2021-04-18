using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    CharacterController m_Controller;
    Vector3 motion;
   
    ICommand m_IcommandMovement;
    ICommand m_IcmdAttack;
    BasicMovement basicMovement;
    HandSwordMovement handSwordMovement;
    SwordAttack swordAttack;
    // Start is called before the first frame update
    void Start()
    {
        basicMovement=new BasicMovement(m_Animator);
        handSwordMovement= new HandSwordMovement(m_Animator);
        swordAttack=new SwordAttack(m_Animator);
        
        m_IcommandMovement=basicMovement;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            ChangeToBasic();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            ChangeToHandSword();
        }
        if(Input.GetMouseButtonDown(0)){
            if(m_IcmdAttack!=null){
                m_IcmdAttack.Execute();
            }
            
            
        }
        if(Input.GetMouseButtonUp(0)){
            if(m_IcmdAttack!=null){
                m_IcmdAttack.Exit();
            }
            
        }
    }
    void SetMoveAnimation(Vector3 move){
        m_Animator.SetFloat("MoveX",  move.x,.1f,Time.deltaTime);
		m_Animator.SetFloat("MoveZ",  move.z,.1f,Time.deltaTime);
    }
     private void FixedUpdate() {
        motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (motion != Vector3.zero)
        {
            m_Controller.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(motion), Time.deltaTime * 10);
        }
        //m_TurnAmount = Mathf.Atan2(motion.x, motion.z);
        SetMoveAnimation(motion);
    }
    void ChangeToBasic(){
        m_IcommandMovement.Exit();
        m_IcmdAttack=null;
        m_IcommandMovement=basicMovement;
        m_IcommandMovement.Execute();
    }
    void ChangeToHandSword(){
        m_IcommandMovement.Exit();
        m_IcmdAttack=swordAttack;
        m_IcommandMovement=handSwordMovement;
        m_IcommandMovement.Execute();
    }
   
}

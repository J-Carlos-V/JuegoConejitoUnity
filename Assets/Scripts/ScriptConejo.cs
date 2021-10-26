using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptConejo : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScriptConejo shareInstance;
    public float FuerzadeSalto = 25.0f;
    public float Velocidad = 2.0f;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayerMask;
    public Animator animator;




    void Awake(){
        
        shareInstance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        GameStatus currentGameStatus = GameManager.sharedInstance.currentGameStatus;
        animator.SetBool("isAlive", true);
    }

    public void StartGame(){
        
        animator.SetBool("isAlive", true);
        rigidBody.velocity = new Vector2(0,0);
    }


    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameStatus==GameStatus.inTheGame){
        if (Input.GetMouseButtonDown(0))
        {
           Saltar();
        }
        animator.SetBool("isGrounded", true);
        }
    }
    
    public void KillPlayer(){
        animator.SetBool("isAlive", false);
        GameManager.sharedInstance.GameOver();
    }

    void FixedUpdate(){
        if(GameManager.sharedInstance.currentGameStatus==GameStatus.inTheGame){
            if (rigidBody.velocity.x<Velocidad){
                rigidBody.velocity = new Vector2(Velocidad,rigidBody.velocity.y);
            }
        }
    }

    void Saltar(){
        if (proximidadad())
        {
            rigidBody.AddForce(Vector2.up*FuerzadeSalto, ForceMode2D.Impulse);
        }else{
            Debug.Log("No Salta");
        }
    }

    bool proximidadad(){
        if (Physics2D.Raycast(this.transform.position, Vector2.down, 2.0f, groundLayerMask.value))
        {
            return true;
        }else
        {
            return false;
        }
    
    }
}
/*
codigo ricardo


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripConejo : MonoBehaviour
{
    public float FuerzaSalto = 25.0f;
    private Rigidbody2D rigidBody;
    public LayerMask groundLayerMask;

    void Awake(){
        rigidBody=GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)){
*/
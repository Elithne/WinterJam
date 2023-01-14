using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public variables
    public float velX;
    public float speed;
    public float jump;

    //private variables
    private Rigidbody2D playerBody;
    private Vector3 direction;
    private bool canJump;


    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
    }

        private void Move(){  
        Vector3 destination = transform.position + direction;   
        
        if(Input.GetKey(KeyCode.A)){
            playerBody.AddForce(new Vector2(-speed * Time.deltaTime, 0));         
        }
        
        if(Input.GetKey(KeyCode.D)){
            playerBody.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            playerBody.AddForce(new Vector2(0, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "floor" || collision.transform.tag == "box"){
            canJump = true;
        }
    }
}

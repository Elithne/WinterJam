using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public variables
    public float speed;
    public float jumpingPower;

    //private variables
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector3 direction;
    private bool isGrounded;
    private float horizontal; //Para donde se está moviendo
    private bool isFacingRight = true;


    void Awake(){
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
        Flip();
    }

    private void FixedUpdate(){
        playerBody.velocity = new Vector2(horizontal * speed, playerBody.velocity.y);    
        
    }

    //Cambio de dirección
    private void Flip(){
        //Esto va a cambiar la dirección de X, haciéndola del valaor opuesto al actual para que gire y cambie dirección.
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    //Lógica de Salto
    private void Jump(){
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && playerBody.velocity.y > 0f){
            playerBody.velocity = new Vector2(playerBody. velocity.x, playerBody.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);//Esto crea un circulo invisible en los pies del personajes, y cuando colisione con el layer "groundLayer" va a saltar.
    }   
}

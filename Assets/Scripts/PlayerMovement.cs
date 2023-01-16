using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //audio
    public AudioSource aSjump;
    public AudioClip[] jumpSound;

    //public variables
    public Animator animator; //Como necesitamos controlar el animador a travé sdel script, lo referenciamos.
    public float speed;
    public float jumpingPower;
    public bool canMove;


    //private variables
    [SerializeField] private Rigidbody2D playerBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector3 direction;
    private bool isGrounded;
    private float horizontal; //Para donde se está moviendo
    private bool isFacingRight = true;


    void Awake(){
        canMove = true;
        playerBody = GetComponent<Rigidbody2D>();

        //audio
        aSjump = gameObject.AddComponent<AudioSource>();
    }

    void Update(){
        if(canMove){
            horizontal = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Jump();
            Flip();
        } else {
            playerBody.velocity = new Vector2(0, 0);
        }
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

            //audio
            int currentSound  = Random.Range(0, jumpSound.Length);
            AudioSource.PlayClipAtPoint(jumpSound[currentSound], transform.position);
        }

        if(Input.GetButtonUp("Jump") && playerBody.velocity.y > 0f){
            playerBody.velocity = new Vector2(playerBody. velocity.x, playerBody.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);//Esto crea un circulo invisible en los pies del personajes, y cuando colisione con el layer "groundLayer" va a saltar.
    }
}

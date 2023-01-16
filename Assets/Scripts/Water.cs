using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    public float velocidadY;
    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        StartCoroutine(StartMoving());
    }

    void Update(){
        if(canMove){
            Move();
        }
    }

    public IEnumerator StartMoving(){
        yield return new WaitForSeconds(3f);
        canMove = true;
    }

    public void Move(){
        transform.Translate(0, velocidadY * Time.deltaTime, 0);
    } 

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.CompareTag("Player")){
        //sonido
        StartCoroutine(FinishGame());
        }
    }

    public IEnumerator FinishGame(){
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level1");
    }

}

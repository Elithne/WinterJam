using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public Sprite spriteChange;
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    public AudioSource aSdoorOpenSound;
    

    private void Awake(){
        door = doorGameObject.GetComponent<IDoor>();
    }


    private void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.Return)){
             GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteChange;
            door.OpenDoor();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPlatform : MonoBehaviour
{
    public bool isElectrified;
    public bool isPlayerParalyzed;
    public Sprite spriteNormal;
    public Sprite spriteShortcuit;

    [SerializeField] private float timeElectrifying = 5.0f;


    void Start()
    {
        isPlayerParalyzed = false;
    }

    void Update(){
        StartCoroutine(Activate());
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            if(isElectrified){
                collision.gameObject.GetComponent<DamageReceived>().ReceiveShock();
                isPlayerParalyzed = true;
                Debug.Log("Player is paralyzed");
            }
        }
    }

    private IEnumerator Activate(){
        if(!isPlayerParalyzed){
            //Debug.Log("On");
            yield return new WaitForSeconds(timeElectrifying);
            TurnOn();
            //Debug.Log("Off");
            yield return new WaitForSeconds(timeElectrifying);
            TurnOff();
            
        }

    }

    private void TurnOff(){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteNormal;
            isElectrified = false;
    }
    private void TurnOn(){       
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteShortcuit;
            isElectrified = true;
    }
}

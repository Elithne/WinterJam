using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPlatform : MonoBehaviour
{
    public bool isElectrified;
    public bool isPlayerParalyzed;
    [SerializeField] private float timeElectrifying = 2.0f;


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
            isElectrified = true;
            Debug.Log("On");
            yield return new WaitForSeconds(timeElectrifying);
            isElectrified = false;
            Debug.Log("Off");
        }

    }
}

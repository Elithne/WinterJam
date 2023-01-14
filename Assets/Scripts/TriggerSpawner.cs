using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public Spawner spawner;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("floor")){
            spawner.SpawnObject();
        }
    }
}

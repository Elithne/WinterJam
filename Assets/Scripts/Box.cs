using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Spawner spawner;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "floor"){
            Destroy(gameObject);
            spawner.SpawnObject();

        }
    }
}

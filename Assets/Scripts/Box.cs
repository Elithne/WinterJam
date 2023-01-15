using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Spawner spawner;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "floor" || collision.transform.tag == "water"){
            Destroy(gameObject);
            spawner.SpawnObject();

        }
    }
}

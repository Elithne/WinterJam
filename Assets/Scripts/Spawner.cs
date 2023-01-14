using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public bool isObjectDestroyed;

    void Start(){
        isObjectDestroyed = true;
        SpawnObject();
    }
    void Update()
    {
       SpawnObject();
        
    }

    public void SpawnObject(){
        if(isObjectDestroyed){
            Instantiate(objectToSpawn, transform.position, transform.rotation);
            isObjectDestroyed = false;
        }
    }

    public void DestroyObject(){
        isObjectDestroyed = true;
    }
}

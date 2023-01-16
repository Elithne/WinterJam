using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Spawner spawner;

    public AudioClip boxRespawnSound;
    public AudioSource audioSrespawn;

    private void Start()
    {
        audioSrespawn = GetComponent<AudioSource>();        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "floor" || collision.transform.tag == "water") {
            audioSrespawn.PlayOneShot(boxRespawnSound);

            Destroy(gameObject, 2f);
            spawner.SpawnObject();            

        }
    }
    
}

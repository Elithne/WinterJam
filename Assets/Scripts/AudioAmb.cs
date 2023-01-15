using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAmb : MonoBehaviour
{
    public AudioSource Amb;
    public AudioMixerSnapshot snap;
    public float FadeIn = 0.001f;
    public float FadeOut = 0.001f;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true)
        {
            Amb.volume += FadeIn;
        }
        else
        {
            Amb.volume -= FadeOut;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterCollider"))
        {
            Debug.Log("Objeto que colisiona: " + other.gameObject.name);
            snap.TransitionTo(0.1f);
            isPlaying = true;
            Amb.volume = 0;
            Amb.Play();
        }
    }



}

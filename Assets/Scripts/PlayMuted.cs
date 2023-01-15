using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayMuted : MonoBehaviour
{
    public AudioSource mx;
    public AudioMixerSnapshot snap;
    public float FadeIn = 0.01f;
    public float timeToReachTransition = 0.01f;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        mx.volume = 0;
        mx.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true)
        {
            mx.volume += FadeIn;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Objeto que colisiona: " + other.transform.name);
            snap.TransitionTo(timeToReachTransition);
            isPlaying = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceived : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [SerializeField] private float timeParalyzed = 1.0f;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ReceiveShock(){
        StartCoroutine(Paralyze());
    }

    private IEnumerator Paralyze(){
        playerMovement.canMove = false;
        yield return new WaitForSeconds(timeParalyzed);
        playerMovement.canMove = true;
    }

}

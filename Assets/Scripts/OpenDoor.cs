using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float doorSpeed;
    public float doorMovement;
    
    public void MoveDoor(){
        transform.Translate(doorMovement * doorSpeed, 0, Time.deltaTime);
    }
}

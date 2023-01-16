using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour, IDoor
{
    public void OpenDoor(){
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchBehaviour : MonoBehaviour, IDoor
{
    public void OpenDoor(){
        gameObject.SetActive(false);
    }
}

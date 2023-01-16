using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject hatchA;
    [SerializeField] private GameObject hatchB;

    private IDoor door1;
    private IDoor door2;
    private IDoor door3;

    private void Awake(){
        door1 = door.GetComponent<IDoor>();
        door2 = hatchA.GetComponent<IDoor>();
        door3 = hatchB.GetComponent<IDoor>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            door1.OpenDoor();
        }

        if(Input.GetKeyDown(KeyCode.G)){
            door2.OpenDoor();
        }
        if(Input.GetKeyDown(KeyCode.H)){
            door3.OpenDoor();
        }
    }
}

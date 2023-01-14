using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //Detection point
    public Transform detectionPoint;
    //Detection radius
    private const float detectionRadius = 0.5f;
    //Detection layer
    public LayerMask detectionLayer;

    public GameObject door;

    void Update()
    {
        if(DetectObject()){
            if(InteractInput()){
                print("INTERACT");
                door.SetActive(false);
            }
        }
    }

    //chequeamos input del teclado
    bool InteractInput(){
        return Input.GetKeyDown(KeyCode.F);   
    }

    //chequeamos si está intersectando con un objeto
    bool DetectObject(){
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }
}

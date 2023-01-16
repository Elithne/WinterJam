using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public Sprite spriteChange;

    public void ChangeSprite(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteChange;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateExit : MonoBehaviour
{
    //public GameObject exit;

    private void OnTriggerStay2D(Collider2D collider){
        SceneManager.LoadScene("Victory");
    }
}

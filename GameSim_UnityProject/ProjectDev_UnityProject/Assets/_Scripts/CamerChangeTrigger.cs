using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerChangeTrigger : MonoBehaviour
{

    public GameObject cameraPosition;

    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.tag == "Player" )
        {
            Camera.main.transform.position = cameraPosition.transform.position;
        }
    }
}

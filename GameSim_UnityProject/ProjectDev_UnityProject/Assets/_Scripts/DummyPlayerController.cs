using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerController : MonoBehaviour
{

	// Terrible horrible code, but works for small demo to demostrate camera movement when player moves from screen to screen
	void Update () {
        this.transform.position += new Vector3(Input.GetAxis("Horizontal") * 5f * Time.deltaTime, 0);
    }
}

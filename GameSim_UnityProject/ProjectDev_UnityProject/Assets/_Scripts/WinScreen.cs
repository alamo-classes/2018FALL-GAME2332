using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

	public ProgressManager winner;
	public Text winText;

	void Update ()
	{
		if(winner.hasWon())
		{
			winText.gameObject.SetActive(true);
		}
	}
}

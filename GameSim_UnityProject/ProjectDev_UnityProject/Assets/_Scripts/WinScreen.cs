using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

	public ProgressManager winner;
	public Text winText;
   public Button quitButton;

	void Update ()
	{
		if(winner.HasWon())
		{
			winText.gameObject.SetActive(true);
         quitButton.gameObject.SetActive(true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

	public PlayerHealth player;
	public Sprite[] health;
	Image currImage;
	//int pos = 5;

	void Start()
	{
		currImage = GetComponent<Image>();
	}

	void Update()
	{
		if(player.health < 0)
			currImage.sprite = health[0];
		else if(player.health > 5)
			currImage.sprite = health[health.Length-1];
		else
			currImage.sprite = health[(int)player.health];
	}
}

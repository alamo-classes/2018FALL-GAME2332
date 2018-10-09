using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour 
{
	Item[] inventory = new Item[9];
	int loadPos = 0;
	int handPos = 0;
	Item inHand = null;
		
	void Update()
	{
		//Q & E Switch
		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(handPos == 0)
				handPos = inventory.Length - 1;
			else
				handPos--;

			inHand = inventory[handPos];
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			if(handPos == inventory.Length - 1)
				handPos = 0;
			else 
				handPos++;

			inHand = inventory[handPos];
		}
	
		//if 'K' -> use
		if(Input.GetKeyDown(KeyCode.K))
		{
			inHand.Use();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "KeyItem")
		{
			inventory[loadPos] = other.gameObject.GetComponent<Item>();
			loadPos++;

			inHand = inventory[handPos];
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour 
{
	ArrayList inventory = new ArrayList();
	//Item inHand = null;
		

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Item"/* and Action Key*/)
		{
			inventory.Add(other);
		}
	}
		
	//Select From Inventory

	//DeSelect from Inventory


}

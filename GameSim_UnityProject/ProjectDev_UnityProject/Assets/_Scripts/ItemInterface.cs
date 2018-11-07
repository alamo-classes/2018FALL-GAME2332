using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInterface : MonoBehaviour {

	public PlayerInventory inventory;
	Image inHandImage;
	Text uiText;

	void Start ()
	{
		inHandImage = GetComponentInChildren<Image>();
		uiText = GetComponentInChildren<Text>();

		inHandImage.gameObject.SetActive(false);
		uiText.gameObject.SetActive(false);

	}

	void Update ()
	{
		if(inventory.inHand != null)
		{
			inHandImage.gameObject.SetActive(true);
			uiText.gameObject.SetActive(true);

			inHandImage.sprite = inventory.inHand.itemImage;
		}
	}
}

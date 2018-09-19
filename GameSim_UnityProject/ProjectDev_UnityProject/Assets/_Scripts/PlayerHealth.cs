using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	float health;

	public void addHealth(float heal = 1)
	{
		health += heal;
	}

	public void loseHealth(float damage = 1)
	{
		health -= damage;
	}
}

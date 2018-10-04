using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
		
	public float health;

	void Update()
	{
		Debug.Log("EnemyHealth: " + health);
	}

	public void AddHealth(float heal = 1)
	{
		health += heal;
	}

	public void RemoveHealth(float damage = 1)
	{
		health -= damage;
	}
}

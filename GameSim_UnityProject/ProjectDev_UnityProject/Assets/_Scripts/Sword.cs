using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float timer = 0.15f;
	public float damage = 1;

	bool isActive;

	private float timerCount = 0;
	private BoxCollider2D active;
	private Direction player;

	void Start()
	{
		player = GetComponentInParent<Direction>();
		active = GetComponent<BoxCollider2D>();
		isActive = false;
	}

	void Update ()
	{
		timerCount += Time.deltaTime;

		//Direction -  Offset   /  Size
		//Up -	(0, .2) / (.5, .2)
		//Right - 	(.25, 0)	/ (.2, .5)
		//Down -	(0, -.29) / (.5, .2)
		//Left -	(-.25, 0) / (.2, .5)

		//If/Else
		switch(player.GetFacing())
		{
		case Direction.Facing.Up:
			active.offset = new Vector2(0,.2f);
			active.size = new Vector2(.5f, .2f);
			break;
		case Direction.Facing.Down:
			active.offset = new Vector2(0,-.29f);
			active.size = new Vector2(.5f, .2f);
			break;
		case Direction.Facing.Right:
			active.offset = new Vector2(.25f,0);
			active.size = new Vector2(.2f, .5f);
			break;
		case Direction.Facing.Left:
			active.offset = new Vector2(-.25f,0);
			active.size = new Vector2(.2f, .5f);
			break;
		default:
			break;
		}
			
		if(Input.GetKeyDown(KeyCode.J) && !isActive)
		{
			active.enabled = true;
			isActive = true;
		}

		//TODO: Find Better Timer
		if(timerCount >= timer)
		{
			timerCount = 0;
			isActive = false;
			active.enabled = false;
		}
			
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			other.gameObject.GetComponent<EnemyHealth>().RemoveHealth(damage);
			//current problem: enemy can be hit twice in one swing
		}
	}
}

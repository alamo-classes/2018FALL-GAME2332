using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	public float damage = 1;
	public float attackCooldown = 0f;
	public bool onCooldown;

	float cooldownCount = 0;
	bool isAttacking;
   bool isPlayerHolding;

	private float timerCount = 0;
	private BoxCollider2D hitBox;
	private Direction parent;
	private SpriteRenderer swordImage;

	void Start()
	{
		parent = GetComponentInParent<Direction>();
		hitBox = GetComponent<BoxCollider2D>();
		swordImage = GetComponent<SpriteRenderer>();
		isAttacking = false;

      PlayerController test = GetComponentInParent<PlayerController>();
      if (test)
      {
         isPlayerHolding = true;
      }
      else
         isPlayerHolding = false;
	}

	void Update ()
	{

		switch(parent.GetFacing())
		{
		case Direction.Facing.Up:
			this.transform.localPosition = new Vector3(.2f, .4f, 0);
			break;
		case Direction.Facing.Down:
			
			break;
		case Direction.Facing.Right:
			
			break;
		case Direction.Facing.Left:
			
			break;
		default:
			break;
		}

		if(onCooldown)
		{
			cooldownCount += Time.deltaTime;
			if(cooldownCount >= attackCooldown)
			{
				onCooldown = false;
				cooldownCount = 0;
			}
		}

		if(Input.GetKeyDown(KeyCode.J) && !isAttacking && !onCooldown && isPlayerHolding)
		{
			Attack();
			onCooldown = true;
		}

	}

	public void Attack()
	{
		isAttacking = true;
		hitBox.enabled = true;
		swordImage.enabled = true;
		StartCoroutine(AttackAnimation());
	}

	public IEnumerator AttackAnimation() 
	{
		for (float f = 0f; f <= 10; f++)
		{
			transform.RotateAround(parent.gameObject.transform.position, Vector3.forward, 5);
			yield return null;
		}
		isAttacking = false;
		hitBox.enabled = false;
		swordImage.enabled = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy" && isPlayerHolding)
		{
			other.gameObject.GetComponent<EnemyHealth>().RemoveHealth(damage);
         Debug.Log("Hit Enemy");
			//current problem: enemy can be hit twice in one swing
		}
      if ( other.tag == "Player" && !isPlayerHolding)
      {
         other.gameObject.GetComponent<PlayerHealth>().LoseHealth(damage);

         Debug.Log("Hit Player");
      }
      
	}
}

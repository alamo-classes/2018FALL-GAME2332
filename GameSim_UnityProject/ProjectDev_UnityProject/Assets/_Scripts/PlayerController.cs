using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public enum Direction {Up, Down, Right, Left};

   Rigidbody2D playerRigidbody;
   Animator playerAnimator;
   public float speed = 5f;
   public float dashSpeed = 10f;
   public float timeBetweenDashes = 1f;
   public bool canMove = true;
	public Direction dir;
   float timer;
   bool doubleDash = false;


   void Awake()
   {
      playerRigidbody = GetComponent<Rigidbody2D>();
      playerAnimator = GetComponent<Animator>();
      timer = timeBetweenDashes;
   }

   void Update()
   {
      //TODO: Find a better way to handle dash timing
      timer += Time.deltaTime;
      //Debug.Log("Timer:" + timer);
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");
      if ( canMove )
      {
         Move(horizontal, vertical);
         Dash(horizontal, vertical);
      }
      else
      {
         playerAnimator.SetFloat("horizontal", 0f);
         playerAnimator.SetFloat("vertical", 0f);
      }
   }

   void Move(float h, float v)
   {
      playerAnimator.SetFloat("horizontal", h);
      playerAnimator.SetFloat("vertical", v);

		if(v > 0)
			dir = Direction.Up;
		else if(v < 0)
			dir = Direction.Down;

		if(h > 0)
			dir = Direction.Right;
		else if(h < 0)
			dir = Direction.Left;
      
      Vector2 movement = new Vector2(h, v);
      playerRigidbody.AddForce(movement * speed);
   }

   void Dash(float h, float v)
   {
      Vector2 movement = new Vector2(h, v);

      if (doubleDash)
      {
         if (Input.GetKeyDown(KeyCode.Space) && timer >= timeBetweenDashes)
         {
            playerRigidbody.AddForce(movement * dashSpeed);
            timer = 0f;
         }
         if (Input.GetKeyDown(KeyCode.Space) && timer >= (timeBetweenDashes / 2))
         {
            playerRigidbody.AddForce(movement * dashSpeed);
            timer = 0f;
         }
      }
      else
      {
         if (Input.GetKeyDown(KeyCode.Space) && timer >= timeBetweenDashes)
         {
            playerRigidbody.AddForce(movement * dashSpeed);
            timer = 0f;
         }
      }
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("DoubleDash"))
      {
         doubleDash = true;
         Destroy(other.gameObject);
      }
   }
}

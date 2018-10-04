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
	public Direction dir;
   float timer;


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
      Move(horizontal, vertical);
      Dash(horizontal, vertical);
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

      if (Input.GetKeyDown(KeyCode.Space) && timer >= timeBetweenDashes)
      {
         playerRigidbody.AddForce(movement * dashSpeed);
         timer = 0f;
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   Direction direction;

   Rigidbody2D playerRigidbody;
   Animator playerAnimator;
   public float speed = 5f;
   public float dashSpeed = 10f;
   public float timeBetweenDashes = 1f;
   public bool canMove = true;
   float timer;
   bool doubleDash = false;
   bool canDoubleDash = false;
   ProgressManager progressManager;


   void Awake()
   {
      direction = GetComponent<Direction>();
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
      if (canMove)
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

      if (v > 0)
         direction.SetFacing( Direction.Facing.Up);
      else if (v < 0)
         direction.SetFacing(Direction.Facing.Down);
      if (h > 0)
         direction.SetFacing(Direction.Facing.Right);
      else if (h < 0)
         direction.SetFacing(Direction.Facing.Left);

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
            canDoubleDash = true;
            Debug.Log("First dash...");
         }
         else if (Input.GetKeyDown(KeyCode.Space) && canDoubleDash)
         {
            playerRigidbody.AddForce(movement * dashSpeed);
            canDoubleDash = false;
            Debug.Log("Second dash...");
         }
      }
      else
      {
         if (Input.GetKeyDown(KeyCode.Space) && timer >= timeBetweenDashes)
         {
            playerRigidbody.AddForce(movement * dashSpeed);
            timer = 0f;
            Debug.Log("Single dash...");
         }
      }
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("DoubleDash"))
      {
         doubleDash = true;
         Destroy(other.gameObject);
         ProgressManager.keyItemCounter++;
         ProgressManager.hasDoubleDash = true;
      }
   }
}

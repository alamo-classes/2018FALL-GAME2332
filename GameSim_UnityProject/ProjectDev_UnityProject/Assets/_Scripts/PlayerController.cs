using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   Rigidbody2D playerRigidbody;
   Animator playerAnimator;
   public float speed = 5f;
   public float dashSpeed = 10f;
   public float timeBetweenDashes = 1f;
   float timer;
   bool doubleDash = false;
   int dashCount;

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

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("DoubleDash"))
      {
         doubleDash = true;
         Destroy(other.gameObject);
      }
   }
}

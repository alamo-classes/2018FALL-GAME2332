using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayerController : MonoBehaviour
{
   Rigidbody2D playerRigidbody;
   public float speed = 5f;
   void Awake()
   {
      playerRigidbody = GetComponent<Rigidbody2D>();
      
   }

   void FixedUpdate()
   {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");
      Move(horizontal, vertical);
   }

   void Move(float h, float v)
   {
      Vector2 movement = new Vector2(h, v);
      playerRigidbody.AddForce(movement * speed);
   }
}

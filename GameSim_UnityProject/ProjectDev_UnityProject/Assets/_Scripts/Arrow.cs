using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   public float speed = 1f;
   public float damage = 1f;


   private Vector2 trajectory;

   // Use this for initialization
   void Awake ( )
   {
       trajectory = new Vector2(speed, 0f);
   }

   // Update is called once per frame
   void Update ( )
   { 
      this.transform.Translate(trajectory * Time.deltaTime);
   }

   void OnTriggerEnter2D ( Collider2D other )
   {
      Debug.Log(other.name);
      if (other.tag == "Enemy")
      {
         other.gameObject.GetComponent<EnemyHealth>().RemoveHealth(damage);
         Debug.Log("hit Enemy");
      }
   }
}

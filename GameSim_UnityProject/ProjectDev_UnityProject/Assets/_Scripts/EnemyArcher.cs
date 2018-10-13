using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{

   public float speed = 1f;
   public float detectRange = 30f;
   public float attackRange = 10f;
   bool moveCloser;
   bool inRange;
   Transform player;
   Rigidbody2D m_rigidBody;

   // Use this for initialization
   void Awake ( )
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
      m_rigidBody = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update ( )
   {
      float detectDistance = (player.transform.position - transform.position).sqrMagnitude;
      
      if ( detectDistance <= detectRange)
      {
         moveCloser = true;
      }

      if ( detectDistance <= attackRange)
      {
         inRange = true;
         moveCloser = false;
      }

      if ( moveCloser)
      {
         transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      }
   }


}

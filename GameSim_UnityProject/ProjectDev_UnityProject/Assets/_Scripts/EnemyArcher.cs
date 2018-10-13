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

      if (detectDistance <= detectRange)
      {
         moveCloser = true;
      }
      else
      {
         moveCloser = false;
      }

      if ( detectDistance <= attackRange)
      {
         inRange = true;
         moveCloser = false;
      }
      else
      {
         inRange = false;
      }

      if ( moveCloser)
      {
         transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      }
      else if ( inRange )
      {
         LineUpShot();
      }
   }

   public void LineUpShot ( )
   {
      float xDist = player.transform.position.x - transform.position.x;
      float yDist = player.transform.position.y - transform.position.y;

      if (transform.position.y > player.transform.position.y)
      {
         yDist *= -1;
      }
      if (transform.position.x > player.transform.position.x)
      {
         xDist *= -1;
      }

      if ( xDist < yDist)
      {
         transform.position = Vector2.MoveTowards( transform.position, 
                                                   new Vector2(player.transform.position.x, transform.position.y), 
                                                   speed * Time.deltaTime);
      }
      else
      {
         transform.position = Vector2.MoveTowards(transform.position,
                                          new Vector2(transform.position.x, player.transform.position.y),
                                          speed * Time.deltaTime);
      }


   }

}

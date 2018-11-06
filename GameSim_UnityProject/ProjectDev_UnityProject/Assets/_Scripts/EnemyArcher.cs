using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : MonoBehaviour
{
   public float speed = 1f;
   public static float detectRange = 50f;
   public static float attackRange = 30f;
   bool moveCloser;
   bool inRange;
   Transform player;
   Rigidbody2D m_rigidBody;
   Direction direction;
   Item item;

   // Use this for initialization
   void Awake ( )
   {
      direction = GetComponent<Direction>();
      player = GameObject.FindGameObjectWithTag("Player").transform;
      m_rigidBody = GetComponent<Rigidbody2D>();
      item = GetComponent<Item>();
   }

   // Update is called once per frame
   void FixedUpdate ( )
   {

      float detectDistance = (player.transform.position - transform.position).sqrMagnitude;

      if (detectDistance <= detectRange)
      {
         moveCloser = true;
         SetDirection();
         AudioManager.inCombat = true;
      }
      else
      {
         moveCloser = false;
         AudioManager.inCombat = false;
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
         m_rigidBody.MovePosition( Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
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
         m_rigidBody.MovePosition( Vector2.MoveTowards( transform.position, 
                                                   new Vector2(player.transform.position.x, transform.position.y), 
                                                   speed * Time.deltaTime));
      }
      else
      {
         m_rigidBody.MovePosition( Vector2.MoveTowards(transform.position,
                                          new Vector2(transform.position.x, player.transform.position.y),
                                          speed * Time.deltaTime) );
      }

      item.Use();
   }

   private void SetDirection ( )
   {
      if (player.position.y > transform.position.y)
         direction.SetFacing(Direction.Facing.Up);
      else
         direction.SetFacing(Direction.Facing.Down);

      if (Mathf.Abs(player.position.y - transform.position.y) < Mathf.Abs(player.position.x - transform.position.x))
      {
         if (player.position.x > transform.position.x)
            direction.SetFacing(Direction.Facing.Right);
         else
            direction.SetFacing(Direction.Facing.Left);
      }

   }

}

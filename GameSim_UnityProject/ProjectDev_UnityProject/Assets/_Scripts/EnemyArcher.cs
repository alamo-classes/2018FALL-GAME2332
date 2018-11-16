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
   int addCounter = 0;
   Animator archerAnim;

   void Awake()
   {
      direction = GetComponent<Direction>();
      player = GameObject.FindGameObjectWithTag("Player").transform;
      m_rigidBody = GetComponent<Rigidbody2D>();
      item = GetComponent<Item>();
      archerAnim = GetComponent<Animator>();
   }

   void FixedUpdate()
   {

      float detectDistance = (player.transform.position - transform.position).sqrMagnitude;

      if (detectDistance <= detectRange)
      {
         moveCloser = true;
         AudioManager.inCombat = true;
         archerAnim.SetBool("isMoving", true);
         SetDirection();
      }
      else
      {
         moveCloser = false;
         archerAnim.SetBool("isMoving", false);
      }

      if (detectDistance <= attackRange)
      {
         inRange = true;
         moveCloser = false;
         archerAnim.SetBool("isMoving", false);
      }
      else
      {
         inRange = false;
         archerAnim.SetInteger("vertical", 0);
         archerAnim.SetInteger("horizontal", 0);
      }

      if (moveCloser)
      {
         m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
         archerAnim.SetBool("isMoving", true);
      }
      else if (inRange)
      {
         LineUpShot();
         archerAnim.SetBool("isMoving", true);
      }

      if ((moveCloser || inRange) && addCounter < 1)
      {
         PlayerController.enemiesInRange++;
         addCounter++;
      }

      if (!moveCloser && !inRange && addCounter > 0)
      {
         PlayerController.enemiesInRange--;
         addCounter--;
      }
   }

   public void LineUpShot()
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

      if (xDist < yDist)
      {
         m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position,
                                                   new Vector2(player.transform.position.x, transform.position.y),
                                                   speed * Time.deltaTime));
      }
      else
      {
         m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position,
                                          new Vector2(transform.position.x, player.transform.position.y),
                                          speed * Time.deltaTime));
      }

      item.Use();
   }

   private void SetDirection()
   {
      if (player.position.y > transform.position.y)
      {
         direction.SetFacing(Direction.Facing.Up);
         archerAnim.SetInteger("vertical", 1);
         archerAnim.SetInteger("horizontal", 0);
      }
      else
      {
         direction.SetFacing(Direction.Facing.Down);
         archerAnim.SetInteger("vertical", -1);
         archerAnim.SetInteger("horizontal", 0);
      }

      if (Mathf.Abs(player.position.y - transform.position.y) < Mathf.Abs(player.position.x - transform.position.x))
      {
         if (player.position.x > transform.position.x)
         {
            direction.SetFacing(Direction.Facing.Right);
            archerAnim.SetInteger("horizontal", 1);
            archerAnim.SetInteger("vertical", 0);
         }
         else
         {
            direction.SetFacing(Direction.Facing.Left);
            archerAnim.SetInteger("horizontal", -1);
            archerAnim.SetInteger("vertical", 0);
         }
      }

   }

   void OnDestroy()
   {
      PlayerController.enemiesInRange--;
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordsman : MonoBehaviour
{
   public float speed = 2f;
   public float detectRange = 30;
   public float swordAttackRange = 5f;
   bool moveCloser;
   bool inSwordRange;
   Transform player;
   Rigidbody2D m_rigidBody;
   Direction direction;
   Sword sword;
   int addCounter = 0;

   void Awake()
   {
      direction = GetComponent<Direction>();
      player = GameObject.FindGameObjectWithTag("Player").transform;
      m_rigidBody = GetComponent<Rigidbody2D>();
      sword = GetComponentInChildren<Sword>();
   }

   void FixedUpdate()
   {
      float detectDistance = (player.transform.position - transform.position).sqrMagnitude;
      DetermineAction(detectDistance);

      if (moveCloser)
      {
         m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
      }
      else if (inSwordRange)
      {
         if (detectDistance > 1f)
            m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
         sword.Attack();
      }
   }

   public void DetermineAction(float detectDistance)
   {
      if (detectDistance <= detectRange)
      {
         moveCloser = true;
         AudioManager.inCombat = true;
         SetDirection();
      }
      else
      {
         moveCloser = false;
      }
      if (detectDistance <= swordAttackRange)
      {
         inSwordRange = true;
         moveCloser = false;
      }
      else
      {
         inSwordRange = false;
      }

      if ((moveCloser ||inSwordRange) && addCounter < 1)
      {
         PlayerController.enemiesInRange++;
         addCounter++;
      }

      if (!moveCloser && !inSwordRange && addCounter > 0)
      {
         PlayerController.enemiesInRange--;
         addCounter--;
      }
   }

   private void SetDirection()
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

   void OnDestroy()
   {
      PlayerController.enemiesInRange--;
   }
}

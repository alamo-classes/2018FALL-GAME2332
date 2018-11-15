using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
   public float speed = 2f;
   public float detectRange = 50f;
   public float attackRange = 30f;
   public float swordAttackRange = 10f;
   bool moveCloser;
   bool inBowRange;
   bool inSwordRange;
   Transform player;
   Rigidbody2D m_rigidBody;
   Direction direction;
   Bow bow;
   Sword sword;
   EnemyHealth enemyHealth;
   Animator bossAnim;

   // Use this for initialization
   void Awake()
   {
      direction = GetComponent<Direction>();
      player = GameObject.FindGameObjectWithTag("Player").transform;
      m_rigidBody = GetComponent<Rigidbody2D>();
      bow = GetComponent<Bow>();
      sword = GetComponentInChildren<Sword>();
      enemyHealth = GetComponent<EnemyHealth>();
      bossAnim = GetComponent<Animator>();
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      float detectDistance = (player.transform.position - transform.position).sqrMagnitude;
      DetermineAction(detectDistance);

      if (moveCloser)
      {
         m_rigidBody.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
      }
      else if (inBowRange)
      {
         LineUpShot();
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
         bossAnim.SetBool("isMoving", true);
         SetDirection();
      }
      else
      {
         moveCloser = false;
         bossAnim.SetBool("isMoving", false);
      }

      if (detectDistance <= attackRange)
      {
         inBowRange = true;
         moveCloser = false;
         bossAnim.SetBool("isMoving", false);
      }
      else
      {
         inBowRange = false;
      }
      if (detectDistance <= swordAttackRange)
      {
         inSwordRange = true;
         inBowRange = false;
         moveCloser = false;
         bossAnim.SetBool("isMoving", false);
      }
      else
      {
         inSwordRange = false;
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

      bow.Use();
   }

   private void SetDirection()
   {
      if (player.position.y > transform.position.y)
      {
         direction.SetFacing(Direction.Facing.Up);
         bossAnim.SetInteger("vertical", 1);
      }
      else
      {
         direction.SetFacing(Direction.Facing.Down);
         bossAnim.SetInteger("vertical", -1);
      }

      if (Mathf.Abs(player.position.y - transform.position.y) < Mathf.Abs(player.position.x - transform.position.x))
      {
         if (player.position.x > transform.position.x)
         {
            direction.SetFacing(Direction.Facing.Right);
            bossAnim.SetInteger("horizontal", 1);
         }
         else
         {
            direction.SetFacing(Direction.Facing.Left);
            bossAnim.SetInteger("horizontal", -1);
         }
      }

   }

   ~FinalBoss()
   {
      if (enemyHealth.health < 1)
      {
         ProgressManager.bossIsDead = true;
         Debug.Log("In Destructor");
      }
   }
}

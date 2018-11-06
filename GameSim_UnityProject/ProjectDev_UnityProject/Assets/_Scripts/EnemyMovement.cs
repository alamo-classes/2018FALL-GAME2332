using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public float speed = 1f;
   public static float detectRange = 10f;
   bool inRange;
   bool playerInStealth;
   float stealthMultiplier;
   Transform player;
   public Transform[] route;
   private int currentRouteDest;
   private int nextRouteDest;
   int addCounter = 0;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
      Patrol();
   }

   void Update()
   {
      float detectDistance = (player.position - transform.position).sqrMagnitude;

      if (detectDistance <= detectRange)
      {
         inRange = true;
         AudioManager.inCombat = true;
      }
      else
      {
         inRange = false;
      }

      if (inRange)
         transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      else
         Patrol();

      if (inRange && addCounter < 1)
      {
         PlayerController.enemiesInRange++;
         addCounter++;
      }

      if (!inRange && addCounter > 0)
      {
         PlayerController.enemiesInRange--;
         addCounter--;
      }
   }

   void Patrol()
   {
      if (route.Length == 0)
         return;

      transform.position = Vector2.MoveTowards(transform.position, route[nextRouteDest].position, speed * Time.deltaTime);

      currentRouteDest = nextRouteDest;
      nextRouteDest = (currentRouteDest + 1) % route.Length;
   }

   ~EnemyMovement()
   {
      PlayerController.enemiesInRange--;
   }
}

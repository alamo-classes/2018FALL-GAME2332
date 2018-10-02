using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public float speed = 1f;
   public float detectRange = 10f;
   bool inRange;
   Transform player;
   public Transform[] route;
   private int routeDest = 0;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
      Patrol();
   }

   void Update()
   {
      float detectDistance = (player.position - transform.position).sqrMagnitude;

      if (detectDistance <= detectRange)
         inRange = true;
      else
         inRange = false;

      if (inRange)
         transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      else
         Patrol();
   }

   void Patrol()
   {
      if (route.Length == 0)
         return;

      transform.position = Vector2.MoveTowards(transform.position, route[routeDest].position, speed * Time.deltaTime);

      routeDest = (routeDest + 1) % route.Length;
   }
}

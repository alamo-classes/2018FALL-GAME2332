using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Item
{
   public GameObject destination;
   GameObject player;

   private void Awake()
   {
      player = GameObject.FindGameObjectWithTag("Player");
   }

   public override void Use()
   {
      //Play teleport animation
      //Should it be interruptible?
      player.transform.position = destination.transform.position;
   }
}

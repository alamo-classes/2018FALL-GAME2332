using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Item
{
   public GameObject destination;
   public new GameObject camera;
   public GameObject cameraDestination;
   GameObject player;
   PlayerHealth playerHealth;

   private void Awake()
   {
      player = GameObject.FindGameObjectWithTag("Player");
      playerHealth = player.GetComponent<PlayerHealth>();

   }

   public override void Use()
   {
      //Play teleport animation
      //Should it wind up?
      //Should it be interruptible?
      player.transform.position = destination.transform.position;
      camera.transform.position = cameraDestination.transform.position;
   }
}

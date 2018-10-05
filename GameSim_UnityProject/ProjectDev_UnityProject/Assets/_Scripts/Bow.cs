using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Item
{
   public GameObject arrow;
   public float fireRate = 1f;

   private PlayerController player;
   private float timer = 0f;

   private void Awake ( )
   {
      player = GetComponent<PlayerController>();
   }

   public override void Use ( )
   {
      if ( timer >= fireRate)
      {
         Shoot();
         timer = 0f;
      }
   }

   private void Update ( )
   {
      timer += Time.deltaTime;
      if (Input.GetKeyDown(KeyCode.P))
         Use();
   }

   private void Shoot ( )
   {
      Vector3 dir = new Vector3();


      switch ( player.dir )
      {
         case PlayerController.Direction.Up :
            dir.z = 90f;
            break;
         case PlayerController.Direction.Left :
            dir.z = 180f;
            break;
         case PlayerController.Direction.Down :
            dir.z = -90f;
            break;
         case PlayerController.Direction.Right :
            dir.z = 0f;
            break;
      }

      GameObject bolt = Instantiate(arrow, this.transform.position, Quaternion.identity) as GameObject;
      bolt.transform.rotation = Quaternion.Euler(dir);
   }
}

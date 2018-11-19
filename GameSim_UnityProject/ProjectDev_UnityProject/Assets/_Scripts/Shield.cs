using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
   public float activeTime = 2f;
   public float coolDownTime = 5f;
   public GameObject shield;

   private PlayerController playerController;
   private PlayerHealth playerHealth;

   private float timer;

   // Use this for initialization
   void Awake ( )
   {
      playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
      playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
      shield.SetActive(false);

   }

   void Update ( )
   {
//      if ( Input.GetKeyDown(KeyCode.K))
//      {
//         Use();
//      }

      timer += Time.deltaTime;
   }

   public override void Use ( )
   {
      if ( timer >= coolDownTime)
      {
         Activate();
         timer = 0f;
      }

   }

   private void Activate ( )
   {
      Debug.Log("Shield activated");
      shield.SetActive(true);
      playerHealth.canTakeDamage = false;
      playerController.canMove = false;
      Invoke("Deactivate", activeTime);
   }

   private void Deactivate ( )
   {
      Debug.Log("Shield deactivated");
      shield.SetActive(false);
      playerHealth.canTakeDamage = true;
      playerController.canMove = true;
   }
}

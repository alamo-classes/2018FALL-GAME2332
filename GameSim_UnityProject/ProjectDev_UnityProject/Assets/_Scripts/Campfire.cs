using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
   PlayerHealth player;


   private void OnTriggerEnter2D ( Collider2D other )
   {
      if (other.tag == "Player")
      {
         player = other.GetComponent<PlayerHealth>();
         StartCoroutine("HealPlayer");
      }
   }


   private void OnTriggerExit2D ( Collider2D other )
   {
      if (other.tag == "Player")
         StopCoroutine("HealPlayer");
   }

   IEnumerator HealPlayer ( )
   {
      while ( true )
      {
         player.AddHealth();
         yield return new WaitForSeconds(2f);
      }
   }

}

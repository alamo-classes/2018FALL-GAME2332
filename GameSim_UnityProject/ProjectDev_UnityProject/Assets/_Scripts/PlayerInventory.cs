using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   Item[] inventory = new Item[9];
   int loadPos = 0;
   int handPos = 0;
   Item inHand = null;
   ProgressManager progressManager;

   void Update()
   {
      //Q & E Switch
      if (Input.GetKeyDown(KeyCode.Q))
      {
         int newPos = handPos;
         newPos--;

         if (newPos < 0 || inventory[newPos] == null)
            newPos = loadPos - 1;

         handPos = newPos;

         inHand = inventory[handPos];
         Debug.Log("Current Item: " + inHand.gameObject.name);
      }

      if (Input.GetKeyDown(KeyCode.E))
      {
         int newPos = handPos;
         newPos++;

         if (newPos > inventory.Length - 1 || inventory[newPos] == null)
            newPos = 0;

         handPos = newPos;

         inHand = inventory[handPos];
         Debug.Log("Current Item: " + inHand.gameObject.name);
      }

      Debug.Log("HandPos: " + handPos);

      //if 'K' -> use
      if (Input.GetKeyDown(KeyCode.K) && inHand != null)
      {
         inHand.Use();
      }
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "KeyItem" && loadPos < inventory.Length)
      {
         inventory[loadPos] = other.gameObject.GetComponent<Item>();
         loadPos++;

         ProgressManager.keyItemCounter++;
         inventory[loadPos].gameObject.transform.position = progressManager.itemBuffer[ProgressManager.keyItemCounter].gameObject.transform.position;

         inHand = inventory[handPos];
         Debug.Log("Current Item: " + inHand.gameObject.name);
      }
   }
}
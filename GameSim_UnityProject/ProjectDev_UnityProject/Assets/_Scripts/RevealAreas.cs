using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealAreas : MonoBehaviour
{
   FakeObjectsRegistry registry;
   // Use this for initialization
   void Awake ( )
   {
      registry = GameObject.FindGameObjectWithTag("FakeObjectRegistry").GetComponent<FakeObjectsRegistry>();
   }



   private void OnTriggerEnter2D ( Collider2D other )
   {
      if ( other.tag == "Player")
      {
         registry.HideAllFakeObjects();
      }
   }
}

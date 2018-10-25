using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Item
{
   Light torchLight;
   bool isLit = false;

   private void Start()
   {
      torchLight = GameObject.Find("Point Light").GetComponent<Light>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
      {
         isLit = false;
         torchLight.enabled = isLit;
      }
   }

   public override void Use()
   {
      isLit = !isLit;
      torchLight.enabled = isLit;
      Debug.Log("Torched...");
   }
}

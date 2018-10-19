using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : Item
{
   public static bool inStealth = false;
   public static float stealthMultiplier = 2f;

   public override void Use()
   {
      if (!inStealth)
         inStealth = true;
      else if (inStealth)
         inStealth = false;
   }
}

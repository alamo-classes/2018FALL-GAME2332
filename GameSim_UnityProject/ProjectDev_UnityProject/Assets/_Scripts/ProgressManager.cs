using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
   public static int keyItemCounter = -1;
   public static bool hasDoubleDash = false;
   public static bool hasRevealHiddenObjects = false;
   public static bool bossIsDead = false;

   void Update()
   {
      if (keyItemCounter == 4 && hasDoubleDash && hasRevealHiddenObjects)
      {
         Debug.Log("Thing done!");
      }

      if (bossIsDead)
         Debug.Log("You win!");
   }
}

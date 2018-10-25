using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
   public static int keyItemCounter = -1;
   static bool hasDoubleDash = false;
   static bool hasRevealHiddenObjects = false;
   public Transform[] itemBuffer;

   void Update()
   {
      if (keyItemCounter == 4 && hasDoubleDash && hasRevealHiddenObjects)
      {
         //Do the thing
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
   public static int keyItemCounter = -1;
   public static bool hasDoubleDash = false;
   public static bool hasRevealHiddenObjects = false;
   public Transform[] itemBuffer;

   void Update()
   {
      if (keyItemCounter == 4 && hasDoubleDash && hasRevealHiddenObjects)
      {
         //Do the thing
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
   public static int keyItemCounter = -1;
   public static bool hasDoubleDash = false;
   public static bool hasRevealHiddenObjects = false;
   public static bool bossIsDead = false;

	bool allItems = false;
	bool finalBossDone = false;

   void Update()
   {
      if (keyItemCounter == 4 && hasDoubleDash && hasRevealHiddenObjects)
      {
			allItems = true;
      }

      if (bossIsDead)
			finalBossDone = true;

   }

	public bool hasWon()
	{
		return (allItems && finalBossDone);
	}
}

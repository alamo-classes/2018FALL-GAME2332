using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public AudioClip villageTheme;
   public AudioClip inCombatTheme;
   public AudioClip outOfCombatTheme;
   AudioSource backgroundMusic;
   public static bool inCombat = false;
   public static bool inVillage = true;

   void Start()
   {
      backgroundMusic = GetComponent<AudioSource>();
      backgroundMusic.clip = villageTheme;
      backgroundMusic.Play();
   }

   private void Update()
   {
      if (inCombat && backgroundMusic.clip != inCombatTheme)
      {
         backgroundMusic.clip = inCombatTheme;
         backgroundMusic.Play();
      }

      if (!inCombat && !inVillage && backgroundMusic.clip != outOfCombatTheme)
      {
         backgroundMusic.clip = outOfCombatTheme;
         backgroundMusic.Play();
      }

      if (!inCombat && inVillage && backgroundMusic.clip != villageTheme)
      {
         backgroundMusic.clip = villageTheme;
         backgroundMusic.Play();
      }

      //Debug.Log("In the village: " + inVillage);
      //Debug.Log("In combat: " + inCombat);
   }
}

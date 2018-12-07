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
   public float transitionTime = .5f;

   private float maxMusicVolume = .8f;
   private bool changingToCombat = false;
   private bool changingToOutOfCombat = false;
   private bool changingToVillage = false;


   void Start()
   {
      backgroundMusic = GetComponent<AudioSource>();
      backgroundMusic.clip = villageTheme;
      backgroundMusic.Play();
   }

   private void Update()
   {
      if (inCombat && backgroundMusic.clip != inCombatTheme && !changingToCombat)
      {
         StopAllCoroutines();
         changingToOutOfCombat = false;
         changingToVillage = false;
         StartCoroutine ("TransitionToCombatTheme");
      }

      if (!inCombat && !inVillage && backgroundMusic.clip != outOfCombatTheme && !changingToOutOfCombat)
      {
         StopAllCoroutines();
         changingToCombat = false;
         changingToVillage = false;
         StartCoroutine("TransitionToOutOfCombatTheme");
      }

      if (!inCombat && inVillage && backgroundMusic.clip != villageTheme && !changingToVillage)
      {
         backgroundMusic.clip = villageTheme;
         backgroundMusic.Play();

         StopAllCoroutines();
         changingToCombat = false;
         changingToOutOfCombat = false;
         StartCoroutine("TransitionToVillageTheme");
      }
      
      //Debug.Log("In the village: " + inVillage);
      //Debug.Log("In combat: " + inCombat);
   }


   IEnumerator TransitionToCombatTheme ( )
   {
      changingToCombat = true;
      while ( backgroundMusic.volume > 0)
      {
         backgroundMusic.volume -= transitionTime * Time.deltaTime;
         yield return null;
      }

      backgroundMusic.clip = inCombatTheme;
      backgroundMusic.Play();

      while (backgroundMusic.volume < maxMusicVolume)
      {
         backgroundMusic.volume += transitionTime * Time.deltaTime;
         yield return null;
      }

      changingToCombat = false;
   }



   IEnumerator TransitionToOutOfCombatTheme ()
   {
      changingToOutOfCombat = true;
      while (backgroundMusic.volume > 0)
      {
         backgroundMusic.volume -= transitionTime * Time.deltaTime;
         yield return null;
      }

      backgroundMusic.clip = outOfCombatTheme;
      backgroundMusic.Play();

      while (backgroundMusic.volume < maxMusicVolume)
      {
         backgroundMusic.volume += transitionTime * Time.deltaTime;
         yield return null;
      }

      changingToOutOfCombat = false;
   }



   IEnumerator TransitionToVillageTheme ()
   {
      changingToVillage = true;
      while (backgroundMusic.volume > 0)
      {
         backgroundMusic.volume -= transitionTime * Time.deltaTime;
         yield return null;
      }

      backgroundMusic.clip = villageTheme;
      backgroundMusic.Play();

      while (backgroundMusic.volume < maxMusicVolume)
      {
         backgroundMusic.volume += transitionTime * Time.deltaTime;
         yield return null;
      }

      changingToVillage = false;
   }

}

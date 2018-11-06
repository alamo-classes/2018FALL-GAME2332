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

   void Start()
   {
      backgroundMusic = GetComponent<AudioSource>();
      backgroundMusic.clip = villageTheme;
      backgroundMusic.Play();
   }

   private void Update()
   {
      if (inCombat)
      {
         backgroundMusic.clip = inCombatTheme;
         backgroundMusic.Play();
      }
      else if (!inCombat)
      {
         backgroundMusic.clip = outOfCombatTheme;
         backgroundMusic.Play();
      }
   }

   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("OpenWorld") && backgroundMusic.clip != outOfCombatTheme)
      {
         backgroundMusic.clip = outOfCombatTheme;
         backgroundMusic.Play();
      }

      if (other.CompareTag("Village") && backgroundMusic.clip != villageTheme)
      {
         backgroundMusic.clip = villageTheme;
         backgroundMusic.Play();
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   // Singleton
   void Awake ( )
   {
      int numOfMusicControllers = FindObjectsOfType<SceneController>().Length;

      if (numOfMusicControllers > 1)
         Destroy(gameObject);
      else
         DontDestroyOnLoad(this.gameObject);

   }

   public void LoadLevel ( string levelName )
   {
      SceneManager.LoadScene(levelName);
   }

   public void LoadLevel ( int levelIndex )
   {
      SceneManager.LoadScene(levelIndex);
   }

   public void ReloadThisLevel ( )
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}

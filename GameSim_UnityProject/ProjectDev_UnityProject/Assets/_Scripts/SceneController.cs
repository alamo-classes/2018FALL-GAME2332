using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

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

   public void Quit ( )
   {
      Application.Quit();
   }

}

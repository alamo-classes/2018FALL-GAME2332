using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeObjectsRegistry : MonoBehaviour
{

   private List<GameObject> fakeObjects = new List<GameObject>();


   public void RegisterFakeObject( GameObject obj )
   {
      fakeObjects.Add(obj);
   }


   public void HideAllFakeObjects ( )
   {
      for ( int ind = 0; ind < fakeObjects.Count; ind++)
      {
         fakeObjects[ind].SetActive(false);
      }
   }

}

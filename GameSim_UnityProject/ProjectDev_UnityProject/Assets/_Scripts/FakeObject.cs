using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeObject : MonoBehaviour
{
   void Awake ( )
   {
      GameObject.FindGameObjectWithTag("FakeObjectRegistry").GetComponent<FakeObjectsRegistry>().RegisterFakeObject(this.gameObject);
   }

}

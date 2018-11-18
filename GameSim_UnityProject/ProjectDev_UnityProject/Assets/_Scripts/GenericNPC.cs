using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericNPC : MonoBehaviour
{

   [SerializeField] GameObject dialogueBox;
   [SerializeField] Text text;
   [SerializeField] string[] dialogue;

   // Use this for initialization
   void Start ( )
   {
      text.text = "";
      dialogueBox.SetActive(false);
   }

   // Update is called once per frame
   void Update ( )
   {

   }


   private void OnTriggerEnter2D ( Collider2D other )
   {
      if ( other.tag == "Player" )
      {
         int rand = Random.Range(0, dialogue.Length);
         text.text = dialogue[rand];
         dialogueBox.SetActive(true);
      }
   }

   private void OnTriggerExit2D ( Collider2D other )
   {
      if ( other.tag == "Player" )
      {
         text.text = "";
         dialogueBox.SetActive(false);
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

   public float health;

   public GameObject healthOrb;

   void Update()
   {
      if (health <= 0)
      {
         GameObject orb = Instantiate(healthOrb);
         orb.GetComponent<HealthOrb>().healingPoints = Random.Range(1, 2);
         orb.gameObject.transform.position = this.transform.position;
         Destroy(gameObject);
      }
   }

   public void AddHealth(float heal = 1)
   {
      health += heal;
   }

   public void RemoveHealth(float damage = 1)
   {
      health -= damage;
   }
}

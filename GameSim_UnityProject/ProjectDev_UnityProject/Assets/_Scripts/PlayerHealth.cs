using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

   public float health;

   public void addHealth(float heal = 1)
   {
      health += heal;
   }

   public void loseHealth(float damage = 1)
   {
      health -= damage;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      GameObject obj = other.gameObject;
      HealthOrb healingOrb = other.GetComponent<HealthOrb>();
      EnemyAttack attack = other.GetComponent<EnemyAttack>();

      if (healingOrb)
      {
         addHealth(healingOrb.HealingPoints());
         Destroy(other.gameObject);
      }

      if (attack)
      {
         loseHealth(attack.attackDamage);
      }
   }


}

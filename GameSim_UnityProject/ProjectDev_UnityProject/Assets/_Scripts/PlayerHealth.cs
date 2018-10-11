using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

   public float health;
   bool isVulnerable = true;
   float timer;
   public float invulnerableTime;
   public bool canTakeDamage = true;
   AudioSource deathSound;
   public GameObject gameOverScreen;
   PlayerController controls;

   void Start()
   {
      deathSound = GetComponent<AudioSource>();
      controls = GetComponent<PlayerController>();
   }

   public void Update()
   {
      timer += Time.deltaTime;
      if (timer > invulnerableTime)
         isVulnerable = true;
      else
         isVulnerable = false;
   }

   public void addHealth(float heal = 1)
   {
      health += heal;
   }

   public void loseHealth(float damage = 1)
   {
      if (canTakeDamage)
         health -= damage;

      if (health <= 0)
         Death();
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

      if (attack && isVulnerable)
      {
         loseHealth(attack.attackDamage);
         timer = 0f;
      }
   }

   void Death()
   {
      controls.canMove = false;
      gameOverScreen.gameObject.SetActive(true);
      deathSound.Play();
   }
}

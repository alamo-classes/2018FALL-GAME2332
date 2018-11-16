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
   bool damaged = false;
   AudioSource deathSound;
   public GameObject gameOverScreen;
   PlayerController controls;
   SpriteRenderer spriteRenderer;

   void Start()
   {
      deathSound = GetComponent<AudioSource>();
      controls = GetComponent<PlayerController>();
      spriteRenderer = GetComponent<SpriteRenderer>();
   }

   public void Update()
   {
      timer += Time.deltaTime;
      if (timer > invulnerableTime)
         isVulnerable = true;
      else
         isVulnerable = false;

      damaged = false;
   }

   public void AddHealth(float heal = 1)
   {
      if ( health < 5)
         health += heal;
   }

   public void LoseHealth(float damage = 1)
   {
      if (canTakeDamage)
      {
         health -= damage;
         spriteRenderer.color = Color.red;
         Invoke("ResetSpriteRenderer", .3f);
      }

      if (health <= 0)
         Death();
   }

   private void ResetSpriteRenderer ( )
   {
      spriteRenderer.color = Color.white;
   }


   private void OnTriggerEnter2D(Collider2D other)
   {
      GameObject obj = other.gameObject;
      HealthOrb healingOrb = other.GetComponent<HealthOrb>();
      EnemyAttack attack = other.GetComponent<EnemyAttack>();

      if (healingOrb)
      {
         AddHealth(healingOrb.HealingPoints());
         Destroy(other.gameObject);
      }

      //if (attack && isVulnerable)
      //{
      //   LoseHealth(attack.attackDamage);
      //   damaged = true;
      //   timer = 0f;
      //}
   }

   void Death()
   {
      controls.canMove = false;
      gameOverScreen.gameObject.SetActive(true);
      deathSound.Play();
   }
}

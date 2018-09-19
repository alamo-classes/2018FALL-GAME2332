using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour {

    public float healingPoints = 1f;

    private void Start()
    {
        this.transform.localScale *= healingPoints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if ( health )
        {
            health.addHealth(healingPoints);
            Destroy(gameObject);
        }
    }

}

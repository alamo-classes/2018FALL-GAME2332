using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour {

    public float healingPoints = 1f;

    private void Start()
    {
        this.transform.localScale *= healingPoints;
    }

    public float HealingPoints ( )
    {
        return healingPoints;
    }
}

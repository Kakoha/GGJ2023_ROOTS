using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        regenRate = 2f;
        InvokeRepeating("Regen", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Regen()
    {
        if (health < maxHealth)
        {
            health += regenRate;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject DeathVFX;

    public void DamageDealer(float damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            TriggerDeathVFX();
        }
    }
    private void TriggerDeathVFX()
    {
        if (!DeathVFX) return;
        GameObject vfx = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 0.5f);
    }
}

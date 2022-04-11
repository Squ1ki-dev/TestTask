using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int bulletDamage;
    [SerializeField] private HeartSystem heartSystem;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy Bullet"))
            Damage();
    }

    public void Damage() // Why doesn’t it work?!?
    {
        heartSystem.playerHealth = heartSystem.playerHealth - bulletDamage;
        heartSystem.UpdateHealth();
    }
}

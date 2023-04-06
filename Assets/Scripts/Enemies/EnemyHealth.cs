using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{ 
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health = 3;
        private int currentHealth;

        private void Start()
        {
            currentHealth = health;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage; 
            Debug.Log(currentHealth);
            Death();
        }
        private void Death()
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


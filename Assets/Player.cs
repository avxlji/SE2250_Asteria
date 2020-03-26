﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthSlider healthBar;
    public GameObject player;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            TakeDamage(20);
        }

        if (other.tag.Equals("Food"))
        {
            GetHealth(20);
            other.gameObject.SetActive(false); //then deactivate the food
        }
    }

    void GetHealth(int health)
    {
        if (currentHealth == 100)
        {
            Debug.Log("Full health");
        }
        else
        {
            currentHealth += health;

            healthBar.SetHealth(currentHealth);
        }
    }

    void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
        else
        {
            player.SetActive(false);
        }
    }
}


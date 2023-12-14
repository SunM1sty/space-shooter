using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public static int enemyCount = 0;
    public int maxHealth = 2;
    public int currentHealth;
    public static int sceneNumber = 0;

    private void Start()
    {
        
        currentHealth = maxHealth;
        enemyCount++;

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name); // выводит в кого попали
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        { 
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        enemyCount--;
    }
}


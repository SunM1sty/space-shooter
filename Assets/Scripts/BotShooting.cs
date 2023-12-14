using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lazer;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Shoot()); // один раз запускаем, потом отрабатываем бесконечно
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            print(EnemyLazerMove.enemyLazerCount);
            print('\n');
            if(EnemyLazerMove.enemyLazerCount <= 3) {
                Instantiate(lazer, firePoint.position, Quaternion.identity);
                yield return new WaitForSeconds(5f); // (Random.Range(0f,3f));
            }
        }
    }
}


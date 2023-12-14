using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lazer;

    void Start()
    {
        StartCoroutine(Shoot()); // один раз запускаем, потом отрабатываем бесконечно
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(lazer, firePoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

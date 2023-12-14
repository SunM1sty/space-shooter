using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private void Start()
    {
        GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;
    }

}


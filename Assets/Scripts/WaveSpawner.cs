using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING, WAITING, COUNTING
    };

    [System.Serializable] // ���� ����������� �������� �� � ���������� � �����
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count; // enemy count ������ 4 �� ����������� �� ����� ������
        public float delay; // == delay between instances
    }

    public Wave[] waves;
    private int nextWave = 0;// index of next wave

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;// in seconds
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        //���������, ���� �� ����� ������
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING) // ����, ���� ���� ������ �� �����
        {
            if (!EnemyIsAlive()) // check if enemies are still alive
            {
                // begin a new round, next wave
                WaveCompleted();

                return;
            }
            else
            {
                return; // ���� ����� ����, �� ������ ���
            }
        }
        if (waveCountdown <= 0)
        { // it's time to spawn
            if (state != SpawnState.SPAWNING)// check if we have already spawned a wave
            {
                StartCoroutine(SpawnWave(waves[nextWave])); // Start spawning wave
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
        
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) // ������ nextWave ��� ��������� �� �����, ������� ���� ������ ���
        {
            nextWave = 0; // ������������ � ������ �����, ����� ������� ��� ����� ����
            Debug.Log("All waves complete! Looping...");
        }
        else
        {
            nextWave++; // ��������� � ��������� �����
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f) // ��������� ������ �������, � �� �����, ����� �� ��������� �� ���� �������� �����
        {
            searchCountdown = 1f; // ���������� �������� ��������
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // ���������, ������� �� ��� �����
            {
                return false;
            }
        }

        return true;
    }
    IEnumerator SpawnWave (Wave _wave)// way of creating methods that will be able to wait before continuing
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        //SPAWN
        for(int i = 0; i < _wave.count; ++i)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.delay); // ��� � �� ����� ������� ������ � ���� �����
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; // �������� �������� ���������
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}



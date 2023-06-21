using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };


    // [SerializeField] private Vector3 spawnPos;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject Wave2;
    [SerializeField] private GameObject Wave3;
    [SerializeField] private GameObject Wave4;
    private float yRotation = 90f;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed All Waves! Looping...");
        }
        nextWave++;
        StartCoroutine("waveCheck");
    }

    IEnumerator waveCheck()
    {
        if (nextWave == 1)
        {
            Wave2.SetActive(true);
            yield return new WaitForSeconds(5f);
            Wave2.SetActive(false);
        }
        if (nextWave == 2)
        {
            Wave3.SetActive(true);
            yield return new WaitForSeconds(5f);
            Wave3.SetActive(false);
        }
        if (nextWave == 3)
        {
            Wave4.SetActive(true);
            yield return new WaitForSeconds(5f);
            Wave4.SetActive(false);
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Vector3 spawnPos = spawnPosition.position;
        Instantiate(_enemy, spawnPos, Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z));
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }

}
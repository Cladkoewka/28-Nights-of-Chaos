using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyWaveData[] _enemyWaves;
    [SerializeField] private float _wavesInterval;


    private int _currentWaveIndex = 0;
    private int _currentEnemyIndex = 0;
    private int _remainingEnemies;

    public bool IsWaveStarted { get; private set; }

    public UnityEvent<float> WaveEnded;
    public UnityEvent<int, int> RemainingEnemiesChanged;
    public UnityEvent<int> WaveStarted;
    public UnityEvent WaveStart;
    public UnityEvent WaveStop;
    private void Start()
    {
        StartNewWave();
    }

    public void StartNewWave()
    {
        if (!IsWaveStarted)
        {
            if (_currentWaveIndex < _enemyWaves.Length)
            {
                IsWaveStarted = true;
                _currentEnemyIndex = 0;
                WaveStarted?.Invoke(_currentWaveIndex);
                WaveStart?.Invoke();
                StartCoroutine(SpawnWave());
            }
            else
            {
                Debug.Log("You Win!");
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        EnemyWaveData currentWave = _enemyWaves[_currentWaveIndex];
        _remainingEnemies = currentWave.EnemiesCount;
        RemainingEnemiesChanged?.Invoke(_remainingEnemies, currentWave.EnemiesCount);

        while (_currentEnemyIndex < currentWave.EnemiesCount)
        {
            SpawnEnemy(currentWave);

            _currentEnemyIndex++;

            yield return new WaitForSeconds(currentWave.SpawnInterval);
        }

        while (_remainingEnemies > 0)
        {
            yield return null;
        }

        IsWaveStarted = false;

        _currentWaveIndex++;

        WaveEnded?.Invoke(_wavesInterval);
        WaveStop?.Invoke();

        yield return new WaitForSeconds(_wavesInterval); 

        StartNewWave();
    }

    private void SpawnEnemy(EnemyWaveData currentWave)
    {
        Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        int newEnemyIndex = Random.Range(0, currentWave.Enemies.Length);
        Enemy enemy = currentWave.Enemies[newEnemyIndex];
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }

    public void OnEnemyDead()
    {
        _remainingEnemies--;
        RemainingEnemiesChanged?.Invoke(_remainingEnemies, _enemyWaves[_currentWaveIndex].EnemiesCount);
    }
}

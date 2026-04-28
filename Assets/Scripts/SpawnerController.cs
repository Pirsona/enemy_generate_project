using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private List<Spawner> _spawnerCollection;
    [SerializeField] private int _spawnDuration;

    private bool _isSpawning = true;
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_spawnDuration);
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (_isSpawning)
        {
            yield return _wait;
            Spawner selectingSpawner = SelectSpawner();
            selectingSpawner.SetupEnemy(_poolEnemy.GetEnemy());
        }
    }

    private Spawner SelectSpawner()
    {
        int index = Random.Range(0, _spawnerCollection.Count);
        Spawner selectingSpawn = _spawnerCollection[index];
        
        return selectingSpawn;
    }
}
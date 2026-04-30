using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PoolEnemy _poolEnemy;
    [SerializeField] private TargetController _target;

    public void CreateEnemy()
    {
        Enemy enemy = _poolEnemy.GetEnemy();
        SetupEnemy(enemy);  
    }

    private void SetupEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;

        enemy.GetTarget(_target);
    }
}
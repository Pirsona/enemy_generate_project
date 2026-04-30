using UnityEngine;
using UnityEngine.Pool;

public class PoolEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _countPoolObject;
    [SerializeField] private int _maximumCountPoolObject;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(CreateObject, ActivateEnemy, DeactivateEnemy, DestroyEnemy, true, _countPoolObject, _maximumCountPoolObject);
    }

    private void ReturnObject(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private Enemy CreateObject()
    {
        Enemy enemyObject = Instantiate(_enemy);
        enemyObject.OnTimeLifeEnd += ReturnObject;
        return enemyObject;
    }

    private void ActivateEnemy(Enemy enemyObject)
    {
        enemyObject.gameObject.SetActive(true);
    }

    private void DeactivateEnemy(Enemy enemyObject)
    {
        enemyObject.gameObject.SetActive(false);
    }

    private void DestroyEnemy(Enemy enemyObject)
    {
        enemyObject.OnTimeLifeEnd -= ReturnObject;
        Destroy(enemyObject.gameObject);
    }

    public Enemy GetEnemy()
    {
        return _pool.Get();
    }
}

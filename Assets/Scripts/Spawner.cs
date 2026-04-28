using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void SetupEnemy(Enemy enemy)
    {
        enemy.transform.position = transform.position;
        enemy.transform.rotation = transform.rotation;

        enemy.SetDirection(transform.forward);
    }
}
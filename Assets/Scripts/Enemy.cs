using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private float _speed;

    public event Action<Enemy> OnTimeLifeEnd;
    private TargetController _currentTarget;


    private void Update()
    {
        MoveToThePoint();
    }

    private void OnEnable()
    {
        _collisionDetector.OnCollisionWithTarget += DisabelWithCollision;
    } 

    private void OnDisable()
    {
        _collisionDetector.OnCollisionWithTarget -= DisabelWithCollision;
    }

    private void MoveToThePoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, _speed * Time.deltaTime);
    }

    private void DisabelWithCollision()
    {
        OnTimeLifeEnd?.Invoke(this);
    }

    public void GetTarget(TargetController target)
    {
        _currentTarget = target;
    }
}

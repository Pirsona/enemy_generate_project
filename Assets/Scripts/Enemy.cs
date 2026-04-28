using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _lifeTime;
    [SerializeField] private float _speed;

    public event Action<Enemy> OnTimeLifeEnd;
    private Vector3 _moveDirection;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_lifeTime);
    }

    private void OnEnable()
    {
        StartCoroutine(CycleLife());
    }

    private void Update()
    {
        Move();
    }
     
    private void Move()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 selectingDirection)
    {
        _moveDirection = selectingDirection;
    }

    private IEnumerator CycleLife()
    {
        yield return _wait;
        OnTimeLifeEnd?.Invoke(this);
    }

}

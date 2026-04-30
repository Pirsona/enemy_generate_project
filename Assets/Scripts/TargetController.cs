using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private List<Point> _points;
    [SerializeField] private float _speed;

    private int _currentIndex = 0;

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (transform.position == _points[_currentIndex].transform.position)
        {
          _currentIndex = (_currentIndex + 1) % _points.Count;
        }

        transform.position = Vector3.MoveTowards(transform.position, _points[_currentIndex].transform.position, _speed * Time.deltaTime);
    }
}

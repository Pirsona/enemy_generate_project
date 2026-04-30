using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action OnCollisionWithTarget;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out TargetController target))
        {
            OnCollisionWithTarget?.Invoke();
        }
    }
}
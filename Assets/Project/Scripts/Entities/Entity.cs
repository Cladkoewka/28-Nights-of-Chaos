using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _maxHealth;
    public float Health { get; protected set; }

    public virtual void TakeDamage(float damage)
    {
        if (damage < 0) { return; }

        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Start()
    {
        Health = _maxHealth;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

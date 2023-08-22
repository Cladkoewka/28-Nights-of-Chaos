using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{

    [SerializeField] protected float _bulletSpeed = 10f;
    [SerializeField] protected float _lifetime = 5f;
    [SerializeField] protected float _damage = 1f;
    [SerializeField] protected ParticleSystem _HitEffectPrefab;

    protected Rigidbody _rigidbody;

    protected void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * _bulletSpeed;
        StartCoroutine(TimeDie(_lifetime));
    }

    protected IEnumerator TimeDie(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProjectile : Projectile
{
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
        Instantiate(_HitEffectPrefab, collision.contacts[0].point, Quaternion.identity);
        AudioManager.Instance.PlayFireballHitSound();
        Destroy(gameObject);
    }
}

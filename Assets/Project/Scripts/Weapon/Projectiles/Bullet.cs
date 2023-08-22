using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private bool IsPenetrating = false;

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null) 
        {
            damageable.TakeDamage(_damage);
            AudioManager.Instance.PlayBulletHitEnemySound();
            Instantiate(_HitEffectPrefab, collision.contacts[0].point, Quaternion.identity);
            if (!IsPenetrating)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            AudioManager.Instance.PlayBulletHitWallSound();
            Destroy(gameObject);
        }
        
    }
}

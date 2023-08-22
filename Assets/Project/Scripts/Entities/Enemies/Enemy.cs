using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _attackPeriod;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackDistance = 1f;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected GameObject _HPBarPrefab;
    [SerializeField] protected GameObject[] _itemPrefabs;
    public Transform Target { get; private set; }
    protected EnemyHP _HPBar;
    protected EnemySpawner _enemySpawner;

    public UnityAction EnemyDied;

    protected virtual void Start()
    {
        base.Start();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        Target = FindObjectOfType<Player>().gameObject.transform;
        _HPBar = Instantiate(_HPBarPrefab, transform.position, transform.rotation, transform).GetComponent<EnemyHP>();
        _HPBar.SetTarget(transform);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        _HPBar.UpdateHp(Health, _maxHealth);
    }

    protected override void Die()
    {
        SpawnItem();
        AudioManager.Instance.PlayZombieDeathSound();
        _enemySpawner.OnEnemyDead();
        base.Die();
    }

    protected void SpawnItem()
    {
        int spawnChance = Random.Range(0, 10);
        if (spawnChance < 3) { return; }

        int spawnItem = Random.Range(0, 10);
        GameObject spawnPrefab;

        if (spawnChance < 8) { spawnPrefab = _itemPrefabs[0]; }
        else if (spawnChance == 8) { spawnPrefab = _itemPrefabs[1]; }
        else { spawnPrefab = _itemPrefabs[2]; }

        GameObject newItem = Instantiate(spawnPrefab, transform.position,transform.rotation);
    }

    public void MoveToTarget()
    {
        Vector3 directionToTarget = Target.position - transform.position;
        directionToTarget.y = 0;
        Vector3 newPosition = transform.position + directionToTarget.normalized * _movementSpeed * Time.deltaTime;
        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(directionToTarget);
    }

    public bool IsTargetNear()
    {
        if ((Target.position - transform.position).magnitude < _attackDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawn;

    private RangeEnemyStateMachine _stateMachine;
    private float _timer = 0;

    protected override void Start()
    {
        base.Start();
        _stateMachine = new RangeEnemyStateMachine(this);
        _stateMachine.Initialize(new RangeEnemyIdleState());
    }
    private void Update()
    {
        if (Target == null) { return; }

        _timer += Time.unscaledDeltaTime;

        if (_stateMachine.CurrentState != null)
        {
            _stateMachine.CurrentState.Update(this);
        }
    }

    public void AttackTarget()
    {
        LookToTarget();
        if (_timer > _attackPeriod)
        {
            StartCoroutine(Attack());
        }
    }

    private void LookToTarget()
    {
        Vector3 directionToTarget = Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToTarget);
    }

    public void ChangeState(RangeEnemyState newState)
    {
        _stateMachine.ChangeState(newState);
    }

    private IEnumerator Attack()
    {

        _animator.SetTrigger("Attack");
        _timer = 0;
        yield return new WaitForSeconds(1.5f);
        GameObject newProjectile = Instantiate(_projectilePrefab, _projectileSpawn.position, _projectileSpawn.rotation);
    }
}

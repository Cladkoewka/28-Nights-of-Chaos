using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{

    private MeleeEnemyStateMachine _stateMachine;
    private float _timer = 0;

    protected override void Start()
    {
        base.Start();
        _stateMachine = new MeleeEnemyStateMachine(this);
        _stateMachine.Initialize(new MeleeEnemyIdleState());
    }

    private void Update()
    {
        if (Target == null) { return;  }

        _timer += Time.unscaledDeltaTime;
        
        if (_stateMachine.CurrentState != null)
        {
            _stateMachine.CurrentState.Update(this);
        }
    }

    public void AttackTarget()
    {
        if (_timer > _attackPeriod)
        {
            StartCoroutine(Attack());
        }
    }

    public void ChangeState(MeleeEnemyState newState)
    {
        _stateMachine.ChangeState(newState);
    }

    private IEnumerator Attack()
    {

        _animator.SetTrigger("Attack");
        _timer = 0;
        yield return new WaitForSeconds(_attackPeriod / 2);
        Target.GetComponent<IDamageable>().TakeDamage(_damage);
    }
}

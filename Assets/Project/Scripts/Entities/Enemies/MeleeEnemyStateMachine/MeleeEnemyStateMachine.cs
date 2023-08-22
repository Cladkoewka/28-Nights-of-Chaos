using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStateMachine
{
    public MeleeEnemyState CurrentState { get; private set; }

    private MeleeEnemy _meleeEnemy;

    public MeleeEnemyStateMachine(MeleeEnemy meleeEnemy)
    {
        _meleeEnemy = meleeEnemy;
    }

    public void Initialize(MeleeEnemyState startEnemyState)
    {
        CurrentState = startEnemyState;
        CurrentState.Enter(_meleeEnemy);
    }

    public void ChangeState(MeleeEnemyState newEnemyState)
    {
        CurrentState.Exit(_meleeEnemy);
        CurrentState = newEnemyState;
        CurrentState.Enter(_meleeEnemy);
    }
}

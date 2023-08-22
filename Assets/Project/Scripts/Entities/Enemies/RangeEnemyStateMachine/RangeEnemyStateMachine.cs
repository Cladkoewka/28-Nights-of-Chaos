using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyStateMachine : MonoBehaviour
{
    public RangeEnemyState CurrentState { get; private set; }

    private RangeEnemy _rangeEnemy;

    public RangeEnemyStateMachine(RangeEnemy rangeEnemy)
    {
        _rangeEnemy = rangeEnemy;
    }

    public void Initialize(RangeEnemyState startEnemyState)
    {
        CurrentState = startEnemyState;
        CurrentState.Enter(_rangeEnemy);
    }

    public void ChangeState(RangeEnemyState newEnemyState)
    {
        CurrentState.Exit(_rangeEnemy);
        CurrentState = newEnemyState;
        CurrentState.Enter(_rangeEnemy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeEnemyState 
{
    public abstract void Enter(RangeEnemy rangeEnemy);
    public abstract void Update(RangeEnemy rangeEnemy);
    public abstract void Exit(RangeEnemy rangeEnemy);
}

public class RangeEnemyIdleState : RangeEnemyState
{
    public override void Enter(RangeEnemy rangeEnemy)
    {
    }

    public override void Exit(RangeEnemy rangeEnemy)
    {
    }

    public override void Update(RangeEnemy rangeEnemy)
    {
        if (rangeEnemy.Target)
        {
            rangeEnemy.ChangeState(new RangeEnemyChaseState());
        }
    }
}

public class RangeEnemyChaseState : RangeEnemyState
{
    public override void Enter(RangeEnemy rangeEnemy)
    {
    }

    public override void Exit(RangeEnemy rangeEnemy)
    {
    }

    public override void Update(RangeEnemy rangeEnemy)
    {
        if (rangeEnemy.Target)
        {
            if (rangeEnemy.IsTargetNear())
            {
                rangeEnemy.ChangeState(new RangeEnemyAttackState());
            }
            else
            {
                rangeEnemy.MoveToTarget();
            }
        }
    }
}

public class RangeEnemyAttackState : RangeEnemyState
{
    public override void Enter(RangeEnemy rangeEnemy)
    {
    }

    public override void Exit(RangeEnemy rangeEnemy)
    {
    }

    public override void Update(RangeEnemy rangeEnemy)
    {
        if (rangeEnemy.Target)
        {
            if (!rangeEnemy.IsTargetNear())
            {
                rangeEnemy.ChangeState(new RangeEnemyChaseState());
            }
            else
            {
                rangeEnemy.AttackTarget();
            }
        }
        else
        {
            rangeEnemy.ChangeState(new RangeEnemyIdleState());
        }
    }
}

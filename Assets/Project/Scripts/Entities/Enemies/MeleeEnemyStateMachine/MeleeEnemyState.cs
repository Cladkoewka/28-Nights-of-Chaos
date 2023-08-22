using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemyState
{
    public abstract void Enter(MeleeEnemy meleeEnemy);
    public abstract void Update(MeleeEnemy meleeEnemy);
    public abstract void Exit(MeleeEnemy meleeEnemy);

}

public class MeleeEnemyIdleState : MeleeEnemyState
{
    public override void Enter(MeleeEnemy meleeEnemy)
    {
    }

    public override void Exit(MeleeEnemy meleeEnemy)
    {
    }

    public override void Update(MeleeEnemy meleeEnemy)
    {
        if (meleeEnemy.Target)
        {
            meleeEnemy.ChangeState(new MeleeEnemyChaseState());
        }
    }
}

public class MeleeEnemyChaseState : MeleeEnemyState
{
    public override void Enter(MeleeEnemy meleeEnemy)
    {
    }

    public override void Exit(MeleeEnemy meleeEnemy)
    {
    }

    public override void Update(MeleeEnemy meleeEnemy)
    {
        if (meleeEnemy.Target)
        {
            if (meleeEnemy.IsTargetNear())
            {
                meleeEnemy.ChangeState(new MeleeEnemyAttackState());
            }
            else
            {
                meleeEnemy.MoveToTarget();
            }
        }
    }
}

public class MeleeEnemyAttackState : MeleeEnemyState
{
    public override void Enter(MeleeEnemy meleeEnemy)
    {
    }

    public override void Exit(MeleeEnemy meleeEnemy)
    {
    }

    public override void Update(MeleeEnemy meleeEnemy)
    {
        if (meleeEnemy.Target)
        {
            if (!meleeEnemy.IsTargetNear())
            {
                meleeEnemy.ChangeState(new MeleeEnemyChaseState());
            }
            else
            {
                meleeEnemy.AttackTarget();
            }
        }
        else
        {
            meleeEnemy.ChangeState(new MeleeEnemyIdleState());
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMoney : CollectableItem
{
    public override void Collect()
    {
        SetRandomValues();
        Bank.Instance.AddMoney(_value);
        base.Collect();
    }
}

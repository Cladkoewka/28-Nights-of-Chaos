using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAmmo : CollectableItem
{
    public override void Collect()
    {
        SetRandomValues();
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.CollectAmmo(_value);
        }

        base.Collect();
    }
}

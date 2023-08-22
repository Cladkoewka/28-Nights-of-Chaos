using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHealth : CollectableItem
{
    public override void Collect()
    {
        SetRandomValues();
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.AddHealth(_value);
        }
        base.Collect();
    }
}

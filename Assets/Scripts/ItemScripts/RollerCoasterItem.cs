using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCoasterItem : UsableItemBase 
{
    public static event Action SummonTheCoaster;
    protected override void UseItemFunctionality()
    {
        base.UseItemFunctionality();
        SummonTheCoaster?.Invoke();
    }
}

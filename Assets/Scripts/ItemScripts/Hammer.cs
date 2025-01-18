using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : UsableItemBase
{
    //TODO: Assign this
    [SerializeField] LayerMask playerLayer;
    protected override void UseItemFunctionality()
    {
        //TODO: Play animation up here or something
        base.UseItemFunctionality();
        Collider2D[] colliders;
        colliders = Physics2D.OverlapCircleAll(facingDirection * 1.3f, 4, playerLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == gameObject)
                continue;
            //TODO: Do the SpinOut bullshit here as well
        }    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : UsableItemBase
{
    //TODO: Assign this

    private Animator _animator;
    [SerializeField] LayerMask playerLayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    protected override void UseItemFunctionality()
    {
        base.UseItemFunctionality();

        _animator.Play("Hit");
        // play sound

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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hammer : UsableItemBase
{
    //TODO: Assign this

    private Animator _animator;
    [SerializeField] LayerMask playerLayer;

    private void Start()
    {

    }
    protected override void UseItemFunctionality()
    {
        base.UseItemFunctionality();
        _animator = GetComponent<Animator>();
        _animator.Play("Hit");
        StartCoroutine(SLAM());
        // play sound


    }

    IEnumerator SLAM()
    {
        yield return new WaitForSeconds(0.6f);
        Collider2D[] colliders;
        colliders = Physics2D.OverlapCircleAll(facingDirection * 1.3f, 4, playerLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == owningPlayer)
                continue;
            collider.GetComponent<PlayerMovement>().SpinOut();
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject, 0.3f);
    }
}

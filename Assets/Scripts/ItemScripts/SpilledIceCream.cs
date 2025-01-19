using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpilledIceCream : UsableItemBase
{
    [SerializeField] float creamSpeed;
    //TODO: Assign this
    [SerializeField] LayerMask layerMask;
    Rigidbody2D rb;
    private void Awake()
    {
        
        Destroy(gameObject, 12);
    }
    protected override void UseItemFunctionality()
    {
        
        base.UseItemFunctionality();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(facingDirection * creamSpeed, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owningPlayer)
            return;

            //TODO: SpinOut bullshit goes here
            collision.GetComponent<PlayerMovement>().SpinOut();
            Destroy(gameObject);
        
    }
}

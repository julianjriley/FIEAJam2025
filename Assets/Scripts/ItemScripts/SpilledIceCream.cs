using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpilledIceCream : UsableItemBase
{
    [SerializeField] float creamSpeed;
    //TODO: Assign this
    [SerializeField] LayerMask layerMask;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 12);
    }
    protected override void UseItemFunctionality()
    {
        base.UseItemFunctionality();

        rb.AddForce(facingDirection * creamSpeed, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != gameObject)
            return;
        if(collision.gameObject.layer == layerMask)
        {
            //TODO: SpinOut bullshit goes here
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : UsableItemBase
{
    Rigidbody2D rb;
    [SerializeField] float ballSpeed;

    //TODO: Call SpinOut function on player when colliding

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4);
    }
    protected override void UseItemFunctionality()
    {
        base.UseItemFunctionality();

        //For Debug Purposes
        //facingDirection = new Vector2(1, 1).normalized;

        rb.AddForce(facingDirection * ballSpeed, ForceMode2D.Impulse);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(collision.GetContact(0).normal * ballSpeed, ForceMode2D.Impulse);
    }
}

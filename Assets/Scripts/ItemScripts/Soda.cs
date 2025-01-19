using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : UsableItemBase
{
    [SerializeField] float sodaSpeed;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] GameObject sodaSpillObject;

    Rigidbody2D rb;
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    protected override void UseItemFunctionality()
    {
        base.UseItemFunctionality();

        rb.AddForce(facingDirection * sodaSpeed, ForceMode2D.Impulse);
        StartCoroutine("ExplosionDelay");

    }
    void Explode()
    {
        Collider2D[] colliders;
        colliders = Physics2D.OverlapCircleAll(facingDirection * 1.3f, 4, playerLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == gameObject)
                continue;
            //TODO: Do the SpinOut bullshit here as well
        }
        GameObject theSpill = Instantiate(sodaSpillObject, gameObject.transform.position, Quaternion.identity);
        theSpill.GetComponent<SodaSpill>().AssignOriginalPlayer(owningPlayer);
        Destroy(gameObject);
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Explode();
    }
}

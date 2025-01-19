using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vomit : MonoBehaviour
{
    public static event Action VomHit;

    [SerializeField] float vomitSpeed;
    //TODO: Assign this
    [SerializeField] LayerMask layerMask;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, 12);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != gameObject)
            return;
        if (collision.gameObject.layer == layerMask)
        {
            VomHit?.Invoke();
            //TODO: SpinOut bullshit goes here
            rb.AddForce(new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y) 
                * vomitSpeed, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}

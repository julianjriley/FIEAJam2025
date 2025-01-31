using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Coaster : MonoBehaviour
{
    public float Force;
    public SplineAnimate splineAnimate;
    public float Lifetime;
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null && other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.GetContact(0).normal.normalized * Force * -1f, ForceMode2D.Impulse);
            other.gameObject.GetComponent<PlayerMovement>().SpinOut(Vector2.zero);
            StartCoroutine(HandleCollisions(other.collider));
        }
    }
    IEnumerator HandleCollisions(Collider2D _collid) {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _collid, true);
        yield return new WaitForSeconds(0.15f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _collid, false);
    }
    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(Lifetime);
        Destroy(this.transform.parent.gameObject);
    }
}

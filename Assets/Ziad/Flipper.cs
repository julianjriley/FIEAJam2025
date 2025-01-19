using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float Force;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null && transform.localEulerAngles.z != 0) {
            Debug.Log("Collision");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.GetContact(0).normal.normalized * Force * -1f, ForceMode2D.Impulse); //Rigidbody _rb = 
            //StartCoroutine(HandleCollisions(other.collider));
        }
    }
    IEnumerator HandleCollisions(Collider2D _collid) {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _collid, true);
        yield return new WaitForSeconds(0.15f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _collid, false);
    }
}

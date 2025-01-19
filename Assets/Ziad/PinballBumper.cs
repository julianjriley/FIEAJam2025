using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballBumper : MonoBehaviour
{
    public float Force;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null) {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.GetContact(0).normal.normalized * Force * -1f, ForceMode2D.Impulse); 
            source.Play();
        }
    }
}

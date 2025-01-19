using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PinballBumper : MonoBehaviour
{
    public float Force;
    private AudioSource source;
    public MMFeedbacks feedback;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null && other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.GetContact(0).normal.normalized * Force * -1f, ForceMode2D.Impulse); 
            source.Play();
            feedback.PlayFeedbacks();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class HandlePlayerCollisions : MonoBehaviour
{
    private AudioSource source;
    public AudioClip PlayerHitSound;

    private Rigidbody2D rb;
    public float MinAttackVelocity;
    public CircleCollider2D frontCollid;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            GameObject _otherPlayer = other.gameObject;
            if (PlayerHitSound != null) {
                source.PlayOneShot(PlayerHitSound, 1f);
            }
            //HandleSpinOuts(_otherPlayer);
        }
    }
    /*private void HandleSpinOuts(GameObject _hitPlayer) {
        if (rb.linearVelocity.x >= MinAttackVelocity) {
            //head on collision
            if (frontCollid.bounds.Contains(_hitPlayer.GetComponent<CircleCollider2D>().bounds.center)) {

            } else {

            }
        }
    }*/
}

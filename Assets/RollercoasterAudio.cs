using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollercoasterAudio : MonoBehaviour
{
    public AudioClip[] Clips;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        int _rand = Random.Range(0, Clips.Length);
        source.PlayOneShot(Clips[_rand], 1f);
    }
}

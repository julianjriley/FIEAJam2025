using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperManager : MonoBehaviour
{
    private Transform pivot1;
    private Transform pivot2;
    public float StartDelay;
    public float TimeBetweenEvents;
    private Animator anim1;
    private Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        pivot1 = transform.GetChild(0);
        pivot2 = transform.GetChild(1);
        anim1 = pivot1.gameObject.GetComponent<Animator>();
        anim2 = pivot2.gameObject.GetComponent<Animator>();
        InvokeRepeating("FlipEvent", StartDelay, TimeBetweenEvents);
    }

    void FlipEvent() {
        int _temp = Random.Range(0, 3);
        if (_temp < 2) {
            int _rand = Random.Range(0, 2);
            if (_rand == 0) {
                anim1.SetTrigger("rotate");
            } else {
                anim2.SetTrigger("rotate");
            }   
        }
        
    }
}

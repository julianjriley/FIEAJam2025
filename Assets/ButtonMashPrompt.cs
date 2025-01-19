using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashPrompt : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null) {
            transform.position = target.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHelp : MonoBehaviour
{
    public GameObject TransitionObj;
    // Start is called before the first frame update
    void Start()
    {
        TransitionObj.SetActive(true);
    }
}

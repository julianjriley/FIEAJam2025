using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CoasterEater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Enter Eater Trigger");
        if (other.gameObject.GetComponent<Coaster>()) {
            Destroy(other.gameObject);
        }
    }
}

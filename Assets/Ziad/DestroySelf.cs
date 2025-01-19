using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestructSelf());
    }

    private IEnumerator DestructSelf() {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}

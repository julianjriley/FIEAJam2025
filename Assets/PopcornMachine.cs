using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornMachine : MonoBehaviour
{
    public static float secondsToFinish = 5;
    public float PopcornLeft;
    public Object[] Popcorn;
    private int counter = 0;
    public Transform[] PopcornTransforms;
    public float SpawnDelay;
    public float Force;
    public Animator DanglyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        SpawnDelay = secondsToFinish/PopcornLeft;
        StartCoroutine(SpawnPopcorn());
    }

    IEnumerator SpawnPopcorn() {
        while (PopcornLeft != 0) {
            int _rand = Random.Range(0, Popcorn.Length);
            GameObject _popcorn = null;
            if (counter % 2 == 0) {
                _popcorn = (GameObject) Instantiate(Popcorn[_rand], PopcornTransforms[0].position, Quaternion.identity);
            } else {
                _popcorn = (GameObject) Instantiate(Popcorn[_rand], PopcornTransforms[1].position, Quaternion.identity);
            } 
            _popcorn.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Force, ForceMode2D.Impulse);
            PopcornLeft--;
            counter++;
            yield return new WaitForSeconds(SpawnDelay);
        }
            DanglyAnimator.SetBool("noMorePopcorn", true);
    }
}

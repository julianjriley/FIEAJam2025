using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornManager : MonoBehaviour
{
    [SerializeField] GameObject popcornObject;

    [SerializeField] int maxPopcorn;
    [SerializeField] int maxPopcornPerBurst;
    [SerializeField] float timeBetweenBursts;
    int popCornInCurrentBurst;

    private float totalPopcornMade;
    private void Start()
    {
        InvokeRepeating("SpawnPopcorn", 0.3f, 0.15f);

    }
    //TODO: Create a script that keeps track of score on each player and we'll have one of them here
    public void SpawnPopcorn()
    {
        GameObject thePopcorn = Instantiate(popcornObject, new Vector3(0,0,0), Quaternion.identity);
        popCornInCurrentBurst += 1;
        totalPopcornMade += 1;
        if(popCornInCurrentBurst >= maxPopcornPerBurst)
        {
            CancelInvoke();
            popCornInCurrentBurst = 0;
            InvokeRepeating("SpawnPopcorn", timeBetweenBursts, 0.3f);
        }
        if (totalPopcornMade >= maxPopcorn)
        {
            CancelInvoke();
        }
    }



}

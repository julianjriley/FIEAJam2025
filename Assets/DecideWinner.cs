using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class DecideWinner : MonoBehaviour
{
    [SerializeField] PopcornMachine[] theMachines;

    private void Start()
    {
        for(int i = 0; i < theMachines.Length; i++)
        {
            theMachines[i].PopcornLeft = ScoreManager.instance.scoreValues[i];
        }

        foreach(var machine in theMachines)
        {
            machine.StartPopping();
        }
    }
}

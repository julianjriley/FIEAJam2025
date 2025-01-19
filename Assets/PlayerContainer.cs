using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    public PlayerScore[] thePlayers;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.instance.playerScores = thePlayers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

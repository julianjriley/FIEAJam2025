using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(ScoreManager.instance.playerScores!=null)
            ScoreManager.instance.playerScores = null;
    }

    // Update is called once per frame

}

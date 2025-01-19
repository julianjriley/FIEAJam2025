using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public PlayerScore[] playerScores;
    public int[] scoreValues;
    public string theWinner;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
            

    }
    void Start()
    {
        StageTimer.OnTimerEnd += GetScores;
    }

    void GetScores()
    {
        int highestScoreIndex = 0;
        int highestScore = 0;
        for (int i = 0;i < scoreValues.Length;i++)
        {
            scoreValues[i] = playerScores[i].GetScore();
            if(scoreValues[i] > highestScore)
            {
                highestScoreIndex = i;
                highestScore = scoreValues[i];
                
            }
                
        }
        switch(highestScoreIndex)
        {
            case 0:
                theWinner = "Sonic Wins!";
                break;
            case 1:
                theWinner = "Lightning McQueen Wins!";
                break;
            case 2:
                theWinner = "Kirby Wins!";
                break;
            case 3:
                theWinner = "Freddy Wins!";
                break;
            default:
                theWinner = "The House Wins!";
                break;
                   
        }

    }

    public int GetHighestScoreIndex()
    {
        Debug.Log("Scorevalues length = " + scoreValues.Length);
        int highestScoreIndex = 0;
        int highestScore = 0;
        for (int i = 0; i < scoreValues.Length;i++)
        {
            scoreValues[i] = playerScores[i].GetScore();
            if(scoreValues[i] > highestScore)
            {
                highestScoreIndex = i;
                highestScore = scoreValues[i];
            }
        }
        return highestScoreIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

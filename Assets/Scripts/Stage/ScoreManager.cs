using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public PlayerScore[] playerScores;
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
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            GameObject[] thePlayers = GameObject.FindGameObjectsWithTag("Player");
            for(int i = 0; i < thePlayers.Length; i++)
            {
                playerScores[0] = thePlayers[i].GetComponent<PlayerScore>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

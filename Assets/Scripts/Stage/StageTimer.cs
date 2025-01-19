using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageTimer : MonoBehaviour
{
    public static event Action <StageTimer> OnTimerStart;
    public static event Action OnTimerEnd;
    public TextMeshProUGUI TimerText;
    private Animator _textAnim;
    public float TotalTime = 60;

    void Start()
    {
        TimerText.text = TotalTime.ToString();
    }

    void Update()
    {
        if (TotalTime == 10)
        {
            // get rid of the crown haver
            // TODO: Make TextChange animation in Animator 
            _textAnim.Play("TextChange");
        }
        if (TotalTime > 0)
        {
            TotalTime -= Time.deltaTime;
            float sec = Mathf.RoundToInt(TotalTime);
            TimerText.text = sec.ToString();
        }
        else
        {
            TotalTime = 0;
            TimerText.text = TotalTime.ToString();

            // play sound
            // connect to leaderboard
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTimer : MonoBehaviour
{
    public static event Action <StageTimer> OnTimerStart;
    public static event Action OnTimerEnd;
    public TextMeshProUGUI CountdownText;
    public TextMeshProUGUI TimerText;
    private Animator _textAnim;
    [SerializeField]
    private float TotalTime = 60;
    [SerializeField]
    private GameObject _transitionObj;
    private bool _hasStarted;

    void Start()
    {
        TimerText.text = TotalTime.ToString();
        _hasStarted = false;
        StartCoroutine(Countdown());
        // Startcoroutine to countdown set a bool hasStarted = false. end of coroutine hasStarted = true;
    }

    IEnumerator Countdown()
    {
        
        yield return new WaitForSeconds(3f);
        _hasStarted = true;
    }
    public float GetTime() {
        return TotalTime;
    }

    void Update()
    {
        if (_hasStarted == true)
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

                StartCoroutine(StartTransitionSequence());
                // play sound
                // connect to leaderboard
            }
        }
        
    }

    IEnumerator StartTransitionSequence()
    {
        //_transitionObj.SetActive(true);
        OnTimerEnd?.Invoke();
        yield return new WaitForSeconds(1f); // Change float to be the length it takes for the transition animation to complete

        SceneManager.LoadScene("Results");

    }
}

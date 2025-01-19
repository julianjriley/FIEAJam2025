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
    public TextMeshProUGUI TimerText;
    private Animator _textAnim;
    [SerializeField]
    private float TotalTime = 60;
    [SerializeField]
    private GameObject _transitionObj;

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

            StartCoroutine(StartTransitionSequence());
            // play sound
            // connect to leaderboard
        }
    }

    IEnumerator StartTransitionSequence()
    {
        _transitionObj.SetActive(true);
        yield return new WaitForSeconds(3f); // Change float to be the length it takes for the transition animation to complete

        SceneManager.LoadScene("Results");

    }
}

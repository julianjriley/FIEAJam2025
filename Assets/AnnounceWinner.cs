using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnnounceWinner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI theWinnerText;

    private void Start()
    {
        Invoke("ShowTheText", 6f);
    }

    void ShowTheText()
    {
        theWinnerText.gameObject.SetActive(true);
        theWinnerText.text = ScoreManager.instance.theWinner;
    }
}

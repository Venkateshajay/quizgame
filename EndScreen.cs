using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FinalScoreText;
    Score ScoreKeeper;
    void Awake()
    {
        ScoreKeeper = FindObjectOfType<Score>();
    }

    public void ShowFinalScore()
    {
        FinalScoreText.text = "Congratulations\nYou scored " + ScoreKeeper.ScoreCalculator() + "%";
    }

   
}

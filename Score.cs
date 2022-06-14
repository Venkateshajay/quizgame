using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int NoofCorrecttAnswers = 0;
    int Questionseen = 0;
    public int GetNoofCorrectAnswers()
    {
        return NoofCorrecttAnswers;
    }
    public void IncrementNoofCorrectAnswers()
    {
        NoofCorrecttAnswers++;
    }
    public int GetQuestionseen()
    {
        return Questionseen;
    }
    public void IncrementQuestionseen()
    {
        Questionseen++;
    }
    
    public int ScoreCalculator()
    {
        return Mathf.RoundToInt((NoofCorrecttAnswers*100) / (float) Questionseen);
    }
}

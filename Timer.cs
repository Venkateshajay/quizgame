using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    float TimerValue;
    [SerializeField] float TimerValueWhenAnswering = 30f;
    [SerializeField] float TimerValueWhenShowing = 10f;
    public bool IsAnsweringQuestion;
    public float FillFraction ;
    public bool LoadNextQuestion;
    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        TimerValue -= Time.deltaTime;
        if (IsAnsweringQuestion)
        {
            if (TimerValue > 0)
            {
                FillFraction = TimerValue / TimerValueWhenAnswering;
            }
            else
            {
                IsAnsweringQuestion = false;
                TimerValue = TimerValueWhenShowing;
            }
        }
        else
        {
            if (TimerValue > 0)
            {
                FillFraction = TimerValue / TimerValueWhenShowing;
            }
            else
            {
                IsAnsweringQuestion = true;
                TimerValue = TimerValueWhenAnswering;
                LoadNextQuestion = true;
            }
        }
        
    }
    public void CancelTimer()
    {
        TimerValue = 0;
    }
}

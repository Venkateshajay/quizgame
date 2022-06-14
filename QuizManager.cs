using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI QuestionText;
    [SerializeField] List<QuestionSO> Questions = new List<QuestionSO>();
    QuestionSO CurrentQuestion; 

    [Header("Answer")]
    [SerializeField] GameObject[] AnswerButtons;
    public bool HasAnsweredEarly = true;

    [Header("Button Colour")]
    [SerializeField] Sprite DefaultSprite;
    [SerializeField] Sprite CorrectAnswerSprite;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI ScoreText;
    Score ScoreKeeper;

    [Header("Timer")]
    [SerializeField] Image TimerImage;
    Timer timer;

    [Header("Progress Bar")]
    [SerializeField] Slider ProgressBar;


    public bool IsCompleted;

    void Awake()
    {
        GetRandomQuestionNumber();
        timer = FindObjectOfType<Timer>();
        ScoreKeeper = FindObjectOfType<Score>();
        ProgressBar.value = 0;
        ProgressBar.maxValue = Questions.Count;

    }
    void Update()
    {
        TimerImage.fillAmount = timer.FillFraction;
        if (timer.LoadNextQuestion)
        {
            if (ProgressBar.value == ProgressBar.maxValue)
            {
                IsCompleted = true;
                return;
            }
            HasAnsweredEarly = false;
            GetNextQuestion();
            timer.LoadNextQuestion = false;  
        }
        else if(!HasAnsweredEarly && !timer.IsAnsweringQuestion)
        {
            DisplayAnswers(-1);
            SetButtonState(false);
        }
        
    }
    void GetNextQuestion()
    {
        
        if (Questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultSprite();
            GetRandomQuestion();
            DisplayQuestion();
            ScoreKeeper.IncrementQuestionseen();
        }
    }

    void GetRandomQuestionNumber()
    {
        int index = Random.Range(0, Questions.Count);
        CurrentQuestion = Questions[index];
        
    }
    void GetRandomQuestion()
    {
        GetRandomQuestionNumber();
        if (Questions.Contains(CurrentQuestion))
        {
            Questions.Remove(CurrentQuestion);
        }
    }

    public void OnAnswerSelected(int index)    
    {
        HasAnsweredEarly = true;
        DisplayAnswers(index);
        timer.CancelTimer();
        SetButtonState(false);
        ScoreText.text = "Score : " + ScoreKeeper.ScoreCalculator() + "%";
        ProgressBar.value++;
        
    }
    void DisplayAnswers(int index)
    {
        int CorrectAnswerIndex;
        CorrectAnswerIndex = CurrentQuestion.GetCorrectAnswerIndex();
        Image ButtonImage;
        if (index == CorrectAnswerIndex)
        {
            QuestionText.text = "Correct";
            ButtonImage = AnswerButtons[index].GetComponent<Image>();
            ButtonImage.sprite = CorrectAnswerSprite;
            ScoreKeeper.IncrementNoofCorrectAnswers();
        }
        else
        {
            string CorrectAnswer = CurrentQuestion.GetAnswers(CorrectAnswerIndex);
            QuestionText.text = "Wrong The correct Answer is " + CorrectAnswer;
            ButtonImage = AnswerButtons[CorrectAnswerIndex].GetComponent<Image>();
            ButtonImage.sprite = CorrectAnswerSprite;
        }
    }
    void DisplayQuestion()
    {
        QuestionText.text = CurrentQuestion.GetQuestion();

        for (int i = 0; i < AnswerButtons.Length; i++)
        {
            TextMeshProUGUI ButtonText = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            ButtonText.text = CurrentQuestion.GetAnswers(i);
        }

    }
    void SetButtonState(bool State)
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Button button = AnswerButtons[i].GetComponent<Button>();
            button.interactable = State;
        }
    }
    void SetDefaultSprite()
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            Image ButtonImage = AnswerButtons[i].GetComponentInChildren<Image>();
            ButtonImage.sprite = DefaultSprite;
        }
    }
}

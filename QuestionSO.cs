using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Question",fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Question = "Enter your Question?";
    [SerializeField] string[] Answers = new string[4];
    [SerializeField] int CorrectAnswerIndex;
    public string GetQuestion()
    {
        return Question;
    }
    public int GetCorrectAnswerIndex()
    {
        return CorrectAnswerIndex;
    }
    public string GetAnswers(int Index)
    {
        return Answers[Index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    QuizManager Quiz;
    EndScreen endscreen;
    private void Awake()
    {
        Quiz = FindObjectOfType<QuizManager>();
        endscreen = FindObjectOfType<EndScreen>();
    }
    void Start()
    {
        
        Quiz.gameObject.SetActive(true);
        endscreen.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (Quiz.IsCompleted)
        {
            endscreen.gameObject.SetActive(true);
            Quiz.gameObject.SetActive(false);
            endscreen.ShowFinalScore();
        }
    }

    public void ReplayScence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

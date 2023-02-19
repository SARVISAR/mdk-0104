using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Questions[] questions= null;
    public Questions[] Questions { get { return questions; } }

    [SerializeField] GameEvents events = null;

    private List<AnswerData> PickAnswers = List<AnswerData>();
    private List<int> FinishedQuestions = new List<int>();
    private int currentQuestion = 0;

    void Start ()
    {
        LoadQuestions();
        foreach (var question.Info)
        {
            Debug.Log(question.Info);
        }

        //Display();
    }

    public void EraseAnswers ()
    {
        PickedAnswers = new List<AnswerData>();
    }

    void Display ()
    {
        EraseAnswers();
        var question = GetRandomQuestion();

        if (events.UpdateQuestionUI != null)
        {
            events.UpdateQuestionUI(question);
        }
        else
        {
            Debug.LogWarning("Ups! Something went wrong while trying to display new Question UI Data. GameEvents.UpdateQuestionUI is null. Issue occured in GameManager.Display() method.");
        }
    }

    Question GetRandomQuestion ()
    {
        var randomIndex = GetRandomQuestionIndex();
        currentQuestion= randomIndex;

        return Questions[currentQuestion];
    }
    int GetRandomQuestionIndex ()
    {
        var random = 0;
        if (FinishedQuestions.Count < Questions.Length)
        {
            do
            {
                random = UnityEngine.Random.Range(0, Questions.Length);
            }while(FinishedQuestions.Contains(random) || random == currentQuestion);
        }
        return random;
    }

    void LoadQuestions ()
    {
        Object[] objs = Resources.loadAll("Questions", typeof(Question));
        _questions = new Question[ogjs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            _questions[i] = (Question)objs[i];
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RehabilitationRace : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text scoreText;
    public Button[] answerButtons;
    public Button backButton; // Nieuwe button voor teruggaan
    public GameObject currentGameObject;
    public GameObject previousGameObject;

    private string[] questions = {
        "Wat is de meest voorkomende botbreuk?",
        "Hoe lang duurt het gemiddeld voordat een gebroken arm geneest?",
        "Welke botten breken het vaakst bij ouderen?",
        "Wat helpt bij sneller herstel van een botbreuk?",
        "Welke symptomen duiden op een gebroken bot?",
        "Wat is een veelvoorkomende oorzaak van botbreuken?",
        "Hoe kan een dokter zien of een bot gebroken is?",
        "Wat kan er misgaan als een bot breekt?",
        "Welke behandeling wordt vaak toegepast bij een gebroken been?",
        "Welke groep mensen loopt het grootste risico op botbreuken?"
    };

    private string[,] answers = {
        { "Sleutelbeen", "Dijbeen", "Wervel" },
        { "4-6 weken", "6-8 weken", "8-12 weken" },
        { "Pols", "Heup", "Ribben" },
        { "Calcium", "Rust", "Beide" },
        { "Zwelling", "Pijn", "Aparte plaatsing van het bot" },
        { "Sporten", "Vallen", "Ziekte" },
        { "Röntgenfoto", "Bloedtest", "MRI-scan" },
        { "Verkeerde genezing", "Infectie", "Niks" },
        { "Gips", "Operatie", "Rust" },
        { "Kinderen", "Ouderen", "Sporters" }
    };

    private int[] correctAnswers = { 0, 1, 1, 2 ,3 ,2 ,1 ,2 ,1 ,2}; // Index van correcte antwoorden
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        DisplayQuestion();
        backButton.onClick.AddListener(OnBackButtonClick); // Voeg event listener toe voor de back button
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];

            for (int i = 0; i < answerButtons.Length; i++)
            {
                TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = answers[currentQuestionIndex, i];
                }
                int index = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => AnswerQuestion(index));
            }
        }
        else
        {
            questionText.text = "Quiz afgelopen! Je score: " + score + "/" + questions.Length;
            foreach (Button btn in answerButtons)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }

    void AnswerQuestion(int chosenIndex)
    {
        if (chosenIndex == correctAnswers[currentQuestionIndex])
        {
            score++;
        }

        currentQuestionIndex++;
        scoreText.text = "Score: " + score;
        DisplayQuestion();
    }

    void OnBackButtonClick()
    {
        currentGameObject.SetActive(false);
        previousGameObject.SetActive(true);
    }
}

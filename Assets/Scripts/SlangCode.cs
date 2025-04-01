using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject currentGameObject;
    public GameObject otherGameObject;
    public GameObject targetGameObject;
    public GameObject quizGameObject;
    public Button button;
    public Button activateButton;
    public Button quizButton;
    public Button feitje2;
    public Button feitje3;
    public GameObject feitje2Object;
    public GameObject feitje3Object;

    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        activateButton.onClick.AddListener(OnActivateButtonClick);
        feitje2.onClick.AddListener(OnFeitje2ButtonClick);
        feitje3.onClick.AddListener(OnFeitje3ButtonClick);
    }

    void OnButtonClick()
    {
        currentGameObject.SetActive(false);
        otherGameObject.SetActive(true);
        quizGameObject.SetActive(false);
        feitje2Object.SetActive(false);
        feitje3Object.SetActive(false);
        targetGameObject.SetActive(false);
    }

    void OnActivateButtonClick()
    {
        targetGameObject.SetActive(true);
        currentGameObject.SetActive(false);
        otherGameObject.SetActive(false);
        feitje2Object.SetActive(false);
        feitje3Object.SetActive(false);
        quizGameObject.SetActive(false);
    }
    void OnFeitje2ButtonClick()
    {
        feitje2Object.SetActive(true);
        feitje3Object.SetActive(false);
        targetGameObject.SetActive(false);
        currentGameObject.SetActive(false);
        otherGameObject.SetActive(false);
        quizGameObject.SetActive(false);
    }
    void OnFeitje3ButtonClick()
    {
        feitje3Object.SetActive(true);
        feitje2Object.SetActive(false);
        targetGameObject.SetActive(false);
        otherGameObject.SetActive(false);
        currentGameObject.SetActive(false);
        quizGameObject.SetActive(false);
    }
    void OnquizGameObjectButtonClick()
    {
        feitje3Object.SetActive(true);
        feitje2Object.SetActive(false);
        targetGameObject.SetActive(false);
        otherGameObject.SetActive(false);
        currentGameObject.SetActive(false);
        quizGameObject.SetActive(true);
    }

}

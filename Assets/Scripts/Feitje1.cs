using UnityEngine;
using UnityEngine.UI;

public class Feitje1 : MonoBehaviour
{
    public Button backButton;
    public GameObject currentGameObject;
    public GameObject previousGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    void OnBackButtonClick()
    {
        currentGameObject.SetActive(false);
        previousGameObject.SetActive(true);
    }
}

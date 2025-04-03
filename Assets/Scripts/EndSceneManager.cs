using TMPro;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public GameObject endScreen;
    public GameObject miniGame;

    private void Start()
    {
        UpdateResultText();
    }

    public void UpdateResultText()
    {
        if (resultText == null)
        {
            Debug.LogError("resultText is not assigned!");
            return;
        }
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null!");
            return;
        }

        resultText.text = GameManager.Instance.resultMessage;
        Debug.Log("Result text updated: " + resultText.text);
    }

    public void PlayAgain()
    {
        GameManager.Instance.ResetResultMessage();
        endScreen.SetActive(false);
        miniGame.SetActive(true);
    }
}

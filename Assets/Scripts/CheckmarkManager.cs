using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckmarkManager : MonoBehaviour
{
    public Transform checkmarkTransform; // The Transform of the checkmark
    public RandomDotGenerator dotGenerator; // Reference to the RandomDotGenerator script
    public EndSceneManager endSceneManager; // Reference to the EndSceneManager script

    public void CheckPosition()
    {
        if (dotGenerator.currentDot != null)
        {
            float distance = Vector3.Distance(checkmarkTransform.position, dotGenerator.currentDot.transform.position);
            if (distance < 0.5f)
            {
                GameManager.Instance.resultMessage = "Je hebt de breuk gevonden";
                Debug.Log("breuk gevonden");
            }
            else
            {
                GameManager.Instance.resultMessage = "oei, je hebt de breuk niet gevonden";
                Debug.Log("Breuk niet gevonden");
            }
        }
        else
        {
            GameManager.Instance.resultMessage = "oei, je hebt de breuk niet gevonden";
            Debug.Log("Geen huidige dot gevonden");
        }

        // Voeg een Debug.Log toe om te controleren of de resultMessage wordt bijgewerkt
        Debug.Log("Result message: " + GameManager.Instance.resultMessage);

        // Update the result text in the end scene
        endSceneManager.UpdateResultText();

    }
}

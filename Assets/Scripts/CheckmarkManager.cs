using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckmarkManager : MonoBehaviour
{
    public Transform checkmarkTransform; // The Transform of the checkmark
    public RandomDotGenerator dotGenerator; // Reference to the RandomDotGenerator script
    public void CheckPosition()
    {
        if (dotGenerator.currentDot != null)
        {
            float distance = Vector3.Distance(checkmarkTransform.position, dotGenerator.currentDot.transform.position);
            if (distance < 0.5f) // Adjust the threshold as needed
            {
                GameManager.Instance.resultMessage = "Je hebt de breuk gevonden";
            }
            else
            {
                GameManager.Instance.resultMessage = "oei, je hebt de breuk niet gevonden";
            }
        }
        else
        {
            GameManager.Instance.resultMessage = "oei, je hebt de breuk niet gevonden";
        }

        // Load the end scene
        SceneManager.LoadScene("Minigame1EndScene");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class RehabilitationRace : MonoBehaviour
{
    public GameObject player;
    public Button exerciseButton;
    public Text strengthText;
    private int strength = 0;

    void Start()
    {
        exerciseButton.onClick.AddListener(OnExerciseButtonClick);
        UpdateStrengthText();
    }

    void OnExerciseButtonClick()
    {
        strength++;
        UpdateStrengthText();
        Debug.Log("Exercise performed! Current strength: " + strength);
    }

    void UpdateStrengthText()
    {
        strengthText.text = "Strength: " + strength;
    }
}

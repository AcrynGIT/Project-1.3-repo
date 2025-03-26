using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    public Text resultText;

    private void Start()
    {
        resultText.text = GameManager.Instance.resultMessage;
    }
}

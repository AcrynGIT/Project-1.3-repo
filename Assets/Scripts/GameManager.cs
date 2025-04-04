using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string resultMessage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetResultMessage()
    {
        resultMessage = string.Empty;
    }
}

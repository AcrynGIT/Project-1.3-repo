using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuMG1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMinigame1()
    {
        SceneManager.LoadScene("Minigame1");
    }
    public void ReturnToMainScreen()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void FinishGame()
    {
        SceneManager.LoadScene("Minigame1EndScene");
    }

}

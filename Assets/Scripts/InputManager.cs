using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SaveInput()
    {
        //TODO: Save userinput on username and password
    }

    public void Login()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StopGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro; // For TextMeshPro

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text messageText;
    public GameObject MainMenu;
    public GameObject LoginMenu;


    private string apiUrl = "http://localhost:5047/api/users";

    public void OnLoginButtonClick()
    {
        StartCoroutine(LoginCoroutine(usernameInput.text, passwordInput.text));
    }

    public void OnRegisterButtonClick()
    {
        StartCoroutine(RegisterCoroutine(usernameInput.text, passwordInput.text));
    }

    IEnumerator LoginCoroutine(string username, string password)
    {
        string jsonData = $"{{\"Username\":\"{username}\",\"Password\":\"{password}\"}}";
        UnityWebRequest request = new UnityWebRequest(apiUrl + "/login", "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Login Success: " + request.downloadHandler.text);
            LoginMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
        else
        {
            Debug.LogError("Login Failed: " + request.error);
            messageText.text = "Invalid Username or Password!";
        }
    }

    IEnumerator RegisterCoroutine(string username, string password)
    {
        string jsonData = $"{{\"Username\":\"{username}\",\"Password\":\"{password}\"}}";
        UnityWebRequest request = new UnityWebRequest(apiUrl + "/register", "POST");

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Registration Success: " + request.downloadHandler.text);
            LoginMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
        else
        {
            Debug.LogError("Registration Failed: " + request.error);
            messageText.text = "Registration Failed!";
        }
    }
}

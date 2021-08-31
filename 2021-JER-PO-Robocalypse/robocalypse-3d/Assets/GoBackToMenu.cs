using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{

    private string URL = "http://192.168.1.12:8080/isNotReady/";

    public void StartGame()
    {
        StartCoroutine(isNotReady());
        SceneManager.LoadScene("Scenes/MainMenu");

    }

    IEnumerator isNotReady()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;
    }
}

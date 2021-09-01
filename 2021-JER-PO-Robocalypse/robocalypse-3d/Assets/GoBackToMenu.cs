using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{

    private string URL = "http://192.168.1.12:8080/isNotReady/";
    private string URLGameState = "http://192.168.1.12:8080/gameIsWaiting/";

    public void StartGame()
    {
        StartCoroutine(isNotReady());
        StartCoroutine(gameIsWaiting());
        SceneManager.LoadScene("Scenes/MainMenu");

    }

    IEnumerator isNotReady()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;
    }

    IEnumerator gameIsWaiting()
    {
        UnityWebRequest www = UnityWebRequest.Get(URLGameState);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;

    }
}

using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour

{

    public Text NomEquipe;

    private string URL = "http://192.168.1.12:8080/ready";


    public void ExitButton() { 

        Application.Quit();

        Debug.Log("Game closed");

    }
    
    public void StartGame()
    {

        StartCoroutine(isReady());

    }

    IEnumerator isReady()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;

        if (value == "true")
        {
            InformationJoueur.nomEquipe = NomEquipe.text.ToString();
            SceneManager.LoadScene("PO-SAJ-HautBas");
        }
    }

}

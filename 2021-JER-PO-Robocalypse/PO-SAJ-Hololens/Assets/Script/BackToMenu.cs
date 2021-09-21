using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    private bool loading = false;
    private string URL = "http://192.168.1.12:8080/game";
    private string URLisNotReady = "http://192.168.1.12:8080/isNotReady";

    private Scene scene;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetSceneByName("InputTapTestt");
	}
	
	// Update is called once per frame
	void Update () {
        backToMenu();
	}

    void backToMenu()
    {
        StartCoroutine(gameIsOver());
        StartCoroutine(gameIsNotReady());
    }

    IEnumerator gameIsOver()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;
        
        if (value == "fini" && loading == false)
        {
            loading = true;
            SceneManager.LoadScene("InputPractice Test");
        }
    }

    IEnumerator gameIsNotReady()
    {
        UnityWebRequest www = UnityWebRequest.Get(URLisNotReady);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    private bool loading = false;
    private string URL = "http://192.168.1.12:8080/game";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void backToMenu()
    {
        StartCoroutine(gameIsOver());
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
            SceneManager.UnloadSceneAsync("InputTapTest");
            SceneManager.LoadScene("InputTapTestt", LoadSceneMode.Single);
        }
    }
}

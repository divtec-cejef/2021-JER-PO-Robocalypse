using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckGameEnding : MonoBehaviour {


    private string gameStateValue;

    // Objet du plan de jeu
    public GameObject pizza;
    public GameObject carrot;
    public GameObject red;
    public GameObject blue;

    // Objet du tutoriel
    public GameObject panel;
    public GameObject cible;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(gameState());
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(gameState());
		if (gameStateValue == "fini")
        {
            afficheTutoriel();
            StartCoroutine(isNotReady());
        }
	}

    void afficheJeu()
    {
        red.SetActive(true);
        blue.SetActive(true);
        pizza.SetActive(true);
        carrot.SetActive(true);


        panel.SetActive(false);
        cible.SetActive(false);
    }

    void afficheTutoriel()
    {
        red.SetActive(false);
        blue.SetActive(false);
        pizza.SetActive(false);
        carrot.SetActive(false);


        panel.SetActive(true);
        cible.SetActive(true);
    }

    IEnumerator isNotReady()
    {
        string URLIsNotReady = "http://192.168.1.12:8080/isNotReady";

        UnityWebRequest www = UnityWebRequest.Get(URLIsNotReady);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;
    }

    IEnumerator gameState()
    {
        string URLGameState = "http://192.168.1.12:8080/game";

        UnityWebRequest www = UnityWebRequest.Get(URLGameState);
        yield return www.SendWebRequest();

        gameStateValue = (string)www.downloadHandler.text;
    }
}

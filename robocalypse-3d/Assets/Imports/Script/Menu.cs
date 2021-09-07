using System;
using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour

{

    private Animator transition;

    public Text NomEquipe;

    private string URL = "http://192.168.1.12:8080/ready";

    public void Start()
    {
        transition = GameObject.FindWithTag("transition").GetComponent<Animator>();
        transition.enabled = false;
    }

    public void ExitButton() { 

        Application.Quit();

        Debug.Log("Game closed");

    }
    
    public void StartGame()
    {
        transition.enabled = true;
        transition.Play("transition_rond_ecran_accueil");
        NomEquipe.color = Color.black;
        StartCoroutine(isReady());

    }

    IEnumerator isReady()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;

        /*if (value == "true")
        {*/
            InformationJoueur.nomEquipe = NomEquipe.text.ToString();

            // yield return StartCoroutine(wait(2));

            SceneManager.LoadScene("PO-SAJ-HautBas");
        //}
    }
    
    IEnumerator wait(float temps)
    {
        yield return new WaitForSeconds(temps);
    }

}

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
    private string URLGameState = "http://192.168.1.12:8080/gameIsStarted";

    private Animator transition;

    /*public void Start()
    {
        // transition = GameObject.FindWithTag("transition").GetComponent<Animator>();
        // transition.enabled = false;
    }*/

    public void ExitButton()
    {

        Application.Quit();

        Debug.Log("Game closed");

    }

    public void StartGame()
    {
        transition = GameObject.FindWithTag("transition").GetComponent<Animator>();

        // NomEquipe.color = Color.black;
        if (!OnePlayerOption.onePlayer)
        {
            StartCoroutine(gameIsStarted());
        }

        StartCoroutine(isReady());

    }

    IEnumerator isReady()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retournée
        string value = (string)www.downloadHandler.text;

        if (value == "true" || OnePlayerOption.onePlayer) //== true
        {
            transition.enabled = true;
            transition.Play("transition_rond_ecran_accueil");

            yield return new WaitForSeconds(1f);

            InformationJoueur.nomEquipe = NomEquipe.text.ToString();
            NomEquipe.text = "";

            Cursor.visible = false;
            SceneManager.LoadScene("PO-SAJ-HautBas");
            print("loaded");
        }
        else
        {
            print("Could not be loaded. Server not ready");
        }
    }

    IEnumerator gameIsStarted()
    {


        UnityWebRequest www = UnityWebRequest.Get(URLGameState);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;



    }

}

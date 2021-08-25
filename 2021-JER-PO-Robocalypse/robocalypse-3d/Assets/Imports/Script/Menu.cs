using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour

{

    public Text NomEquipe;
    

    public void ExitButton() { 

        Application.Quit();

        Debug.Log("Game closed");

    }
    
    public void StartGame()
    {

        InformationJoueur.nomEquipe = NomEquipe.text.ToString();
        SceneManager.LoadScene("PO-SAJ-HautBas");

    }
}

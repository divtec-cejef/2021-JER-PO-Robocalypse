using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetCurrentScore : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nomEquipe;
    public TMPro.TextMeshProUGUI scoreEquipe;

    // Start is called before the first frame update
    void Start()
    {
        nomEquipe.text = InformationJoueur.nomEquipe;
        scoreEquipe.text = InformationJoueur.scoreEquipe.ToString();

        nomEquipe.text = "";
        scoreEquipe.text = "";

        nomEquipe.text = InformationJoueur.nomEquipe;
        scoreEquipe.text = InformationJoueur.scoreEquipe.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

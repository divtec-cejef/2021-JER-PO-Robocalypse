using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{ 

    public string nomCible = "Cible";

    public int nbrPointsParSphere = 1;

    private static int score;

    public Text txt_Score;

    // public GameObject messagePoints;
    
    // Start is called before the first frame update
    void Start()
    {
        txt_Score = GameObject.Find("txt_Score").GetComponent<Text>();

       

        // messagePoints.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Imports/HUD/score/+1.png");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == nomCible)
        {
            // position du projectile au moment de l'impact
            // Vector3 position = transform.position;

            // affichagePoints.transform.position = position;
            // messagePoints = Instantiate(messagePoints, position, Quaternion.identity);


            // REMETTRE
            //Destroy this gameobject
            
            Destroy(gameObject);
            


            // incrémentation points
            /*
            int scoreActuel;
            bool a = int.TryParse(txt_Score.text, out scoreActuel);
            score = scoreActuel + nbrPointsParSphere;
            // nbrPoints++;
            // remplacement du score par le nouveau nombre de points
            txt_Score.text = score.ToString();
            */


            // si la collision est autre que la cible
        } else if (collision.collider.name != "Player")
        {

            // remettre
            Destroy(gameObject);
        }
    }
}

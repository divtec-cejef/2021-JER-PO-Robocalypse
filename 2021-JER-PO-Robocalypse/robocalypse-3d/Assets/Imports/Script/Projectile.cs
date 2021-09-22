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

    private static int score;

    public Text txt_Score;

    
    void Start()
    {
        txt_Score = GameObject.Find("txt_Score").GetComponent<Text>();

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == nomCible)
        {
            
            Destroy(gameObject);
            


            


            // si la collision est autre que la cible
        } else if (collision.collider.name != "Player")
        {

            // remettre
            Destroy(gameObject);
        }
    }
}

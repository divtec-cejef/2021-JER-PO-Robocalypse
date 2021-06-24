using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public string nomCible = "Cible";

    // public int nbrPointsParSphere = 50;

    private int nbrPoints;

    // public GameObject messagePoints;
    
    // Start is called before the first frame update
    void Start()
    {
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

            //Destroy this gameobject
            Destroy(gameObject);
            
            // incrémentation points
            nbrPoints++;
            
            // si la collision est autre que la cible
        } else if (collision.collider.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}

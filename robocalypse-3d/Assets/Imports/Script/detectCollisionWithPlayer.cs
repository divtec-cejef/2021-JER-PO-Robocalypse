using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

// Détecte si un projectile ennemi a touché le joueur et décrémente des points à son score.

public class detectCollisionWithPlayer : MonoBehaviour
{
    public int nbrPointsPenalite = 100;
    public string nomCollider = "astronaute";
    private bool hasBeenTouched = false;
    private GameObject joueur;

    private SpriteRenderer sprite;

    private Text txt_Score;

    private Renderer renderer;

    private bool isCoroutineFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        txt_Score = GameObject.Find("txt_Score").GetComponent<Text>();
        joueur = GameObject.Find(nomCollider);
        // sprite = joueur.GetComponent<SpriteRenderer>();
        renderer = joueur.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }

    public void OnCollisionEnter(Collision collision)
    {
        // décrémenter le score du joueur
        // faire clignoter le joueur (invokeRepeating)
        // afficher "-1" ou "+1" avec animation
        if (collision.collider.name == nomCollider)
        {
            // renderer.material.color = Color.red;

            clignoter();
            
            // récupération de la valeur dans la textbox
            int valeurActuelle = 0;
            bool conversion = int.TryParse(txt_Score.text, out valeurActuelle);

            // score après collision
            int score = (valeurActuelle - nbrPointsPenalite);

            // ne peut pas descendre en-dessous de zéro
            if (score > 0)
            {
                // hasBeenTouched = true;
                txt_Score.text = score.ToString();
            }
            else
            {
                // hasBeenTouched = true;
                txt_Score.text = "0";
            }

        }
    }

    public void clignoter()
    {
        for (int i = 0; i < 3; i++)
        {
            Invoke(nameof(clignoterRouge), .5f);
            Invoke(nameof(clignoterBlanc), .5f);
        }
    }
    public void clignoterRouge()
    {
        print("rouge");
        renderer.material.color = Color.red;
    }

    public void clignoterBlanc()
    {
        print("blanc");
        renderer.material.color = Color.white;
    }
    
    
    /**
         * Change la couleur du cube et attend 0.5 seconde avant de le
         * rendre de nouveau cliquable
         */
    IEnumerator faireClignoterJoueur()
    {
        Material mat = GetComponent<Renderer>().material;

        for (int i = 0; i < 3; i++)
        {
            renderer.material.color = Color.red;

            print("Rouge");
            yield return new WaitForSeconds(10f);
            print("Attente");
            // rend la couleur initial à l'objet

            renderer.material.color = Color.white;

            yield return new WaitForSeconds(10f);
        }

        renderer.material.color = Color.white;

        hasBeenTouched = false;
        isCoroutineFinished = true;
    }
}
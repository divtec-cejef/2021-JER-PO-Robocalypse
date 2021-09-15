using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

// Détecte si un projectile ennemi a touché le joueur et décrémente des points à son score.

public class detectCollisionWithPlayer : MonoBehaviour
{

    public int nbrPointsPenalite = 100;
    public string nomCollider = "astronaute";
    private GameObject joueur;
    


    private SpriteRenderer sprite;

    private TextMeshProUGUI txt_Score;

    private Renderer renderer = new Renderer();

    private bool isTouched;
    private GameObject floatingPoints;
    private GameObject posAstronaute;

    // Start is called before the first frame update
    void Start()
    {
        txt_Score = GameObject.Find("txt_Score").GetComponent<TextMeshProUGUI>();
        joueur = GameObject.Find(nomCollider);
        // sprite = joueur.GetComponent<SpriteRenderer>();
        renderer = joueur.GetComponent<Renderer>();
        floatingPoints = GameObject.Find("-50");
        posAstronaute = GameObject.Find(nomCollider);

        

    }

    // Update is called once per frame
    void Update()
    {
        // eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }

    public void OnCollisionEnter(Collision collision)
    {
        /*if (collision.collider.name == "UFO")
        {
            pizza_particles.Play();
            print("!");

        }*/

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

            // apparition du -50.
            isTouched = true;

            /*if (isTouched)
            {*/
            // faire un random
            // Instantiate(floatingPoints, transform.position + new Vector3(0, 3, -3), Quaternion.identity);
            GameObject cloneMoins50 = Instantiate(floatingPoints, posAstronaute.transform.position /*+ new Vector3(-1, 0.5f, 2) */, Quaternion.identity);

            isTouched = false;
        }

    }
    void OnCollisionExit()
    {
        Destroy(GameObject.Find("-50(Clone)"));
    }

    IEnumerator destroyGameObj(GameObject gameobj) 
    {
        yield return new WaitForSeconds(10f);
          
        yield return new WaitForSeconds(10f);

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

    }

}
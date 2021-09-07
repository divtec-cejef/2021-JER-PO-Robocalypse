using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class UFO : MonoBehaviour
{
    public GameObject player;

    public int nbrPoints;

    private Vector3 choix;
    private Vector3 ancien;

    private SpriteRenderer formeAstronaute;

    // Positions où l'UFO se déplacera la prochaine fois
    // private Vector3 futurePosition;
    Vector3[] positionsPossibles = {(new Vector3(-0.8f, 0.7f, 0.5f)),
        // en haut à droite
        (new Vector3(0.8f,0.7f,0.5f)),
        (new Vector3(1f,0.4f,0.5f)),
        // en haut à gauche
        (new Vector3(-0.7f,0.2f,0.5f)),
        // en bas à gauche
        (new Vector3(-0.7f, -0.7f, 0.5f)),
        // en bas à droite
        (new Vector3(1f, -0.7f, 0.5f))

    };
    

    private Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        // position de l'UFo de départ
        choix = positionsPossibles[0];
        InvokeRepeating(nameof(UFOposition), .1f, 1.9f);

        // rafraîchissement UFO (éviter bug)
        this.enabled = false;
        this.enabled = true;

        formeAstronaute = GameObject.Find("astronaute").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // lévitation
        Vector3 posOffset = new Vector3 ();
        Vector3 tempPos = new Vector3 ();
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * 3f) * 0.05f; // fréquence, amplitude
        
        position = player.transform.position;
        
        // transform.position = position + choix + tempPos; // + choix au lieu de tempPos
        
        // déplacement vers une positino différente
        transform.position = Vector3.MoveTowards(transform.position, position + choix + tempPos, 4 * Time.deltaTime);
    }

    /**
     * Choisit la prochaine position de l'UFO aléatoirement.
     */
    void UFOposition()
    {
        int rand = Random.Range(0, positionsPossibles.Length);

        if (formeAstronaute.sprite.name == "enclume")
        {
            rand = Random.Range(0, positionsPossibles.Length - 4);
        }
        
        choix = positionsPossibles[rand];
        if (choix == ancien)
        {
            choix = positionsPossibles[rand];
        }

        ancien = choix;
    }
    
}

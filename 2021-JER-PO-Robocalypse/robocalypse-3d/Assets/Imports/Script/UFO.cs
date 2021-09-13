using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class UFO : MonoBehaviour
{

    private string URL = "http://192.168.1.12:8080/target";


    private ParticleSystem LASER;
    private ParticleSystem LASER1;
    private ParticleSystem LASER2;

    private bool hasMovedForward = false;

    public GameObject player;

    public int nbrPoints;

    private Vector3 choix;
    private Vector3 ancien;

    private SpriteRenderer formeAstronaute;

    public bool peutTirerLaser = false;

    public string alimentAeliminer;

    Color orange;

    /*
     * positions des tuiles
    */
    private ArrayList positionsTuiles = new ArrayList()
    {
        (new Vector3(-4.14f, 3, -2.57f)),
        (new Vector3(-2.2f, 3, -2.57f)), // 17
        (new Vector3(-0.2f, 3 -2.57f)),
        (new Vector3(1.79f, 3, -2.57f)),
        (new Vector3(3.79f, 3, -2.57f))
    };

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
        LASER = GameObject.Find("LASER").GetComponent<ParticleSystem>();
        LASER.Stop();
        LASER1 = GameObject.Find("LASER 1").GetComponent<ParticleSystem>();
        LASER1.Stop();
        LASER2 = GameObject.Find("LASER 2").GetComponent<ParticleSystem>();
        LASER2.Stop();

        ColorUtility.TryParseHtmlString("#FBB03B", out orange);
        
        StartCoroutine(SetBossTarger());

        // position de l'UFo de départ
        choix = positionsPossibles[0];
        InvokeRepeating(nameof(UFOposition), .1f, 1.9f);

        // rafraîchissement UFO (éviter bug)
        this.enabled = false;
        this.enabled = true;

        formeAstronaute = GameObject.Find("astronaute").GetComponent<SpriteRenderer>();

        // InvokeRepeating("deplacementNormal", .1f, .1f);
        // InvokeRepeating("deplacementNormal", 1, 1f);

        InvokeRepeating("SchemaDeplacement", 1f, .02f);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  SchemaDeplacement()
    {
        StartCoroutine(GetTarget());

        // test serveur
        if (peutTirerLaser && alimentAeliminer != "boss")
        {
            // faire se déplacer l'UFO vers le centre de l'astronaute
            Vector3.MoveTowards(transform.position, player.transform.position, 4 * Time.deltaTime);

            // animation laser

            // destruction carottes ou pizzas
            moveTowards();

        }
        else
        {
            // arrêter les lasers
            LASER.Stop();
            LASER1.Stop();
            LASER2.Stop();
            

            Physics.IgnoreLayerCollision(9, 10, true);
            Physics.IgnoreLayerCollision(8, 10, true);

            if (hasMovedForward && transform.position.z > -2.66f)
            {
                transform.Translate(Vector3.back * (30f/*30f*/ * Time.deltaTime));
                StartCoroutine(SetBossTarger());

            }
            else
            {
                hasMovedForward = false;
                
                StartCoroutine("deplacementNormal", .1f);
            }
            
            // transform.position = choix;
        }

        // Invoke(nameof(moveTowards), 2f);

        ///moveTowards();
    }

    /*
     * Se déplace autour du joueur
    */
    IEnumerator deplacementNormal()
    {
        int speed = 4;
        // lévitation
        Vector3 posOffset = new Vector3();
        Vector3 tempPos = new Vector3();
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * 3f) * 0.05f; // fréquence, amplitude

        position = player.transform.position;

        // transform.position = position + choix + tempPos; // + choix au lieu de tempPos

        // déplacement vers une positino différente
        transform.position = Vector3.MoveTowards(transform.position, position + choix + tempPos, speed * Time.deltaTime); // revoir

        yield return new WaitForSeconds(0);
        
    }

    /**
     * Se déplace vers une direction tout en tirant un rayon laser.
    */
    void moveTowards()
    {
        
        // transform.Translate((Vector3)positionsTuiles[Random.Range(0, 5)] * (0.1f * Time.deltaTime));
        // tant que l'UFO n'est pas à la hauteur max
        if (transform.position.y < 3f)
        {
            
            transform.Translate((Vector3.up) *(4 * Time.deltaTime));
            

        // si l'UFO n'est pas au bout des tuiles
        } else if (transform.position.z <= 10f)
        {
            //transform.Rotate(0, 0, 90);
            LASER.Play();
            LASER1.Play();
            LASER2.Play();
            GameObject.Find("UFO").GetComponent<Collider>().enabled = true;
            transform.Translate(Vector3.forward * (10f * Time.deltaTime));
        }
        else { 
        // si l'UFO est au bout des tuiles
       
            hasMovedForward = true;
            StartCoroutine(SetBossTarger());
            /*
            LASER.Stop();
            LASER1.Stop();
            LASER2.Stop();
            */
            peutTirerLaser = false;


        }
        
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
    }

    IEnumerator wait2()
    {
        yield return(StartCoroutine("WaitForSeconds"));
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

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "pizza(Clone)" && LASER1.startColor == Color.yellow)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.name == "carrot(Clone)" && LASER1.startColor == orange)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            GameObject.Find("UFO").GetComponent<Collider>().enabled = false;
        }
    }

IEnumerator GetTarget()
    {
        // Lance la requette
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // Selon la valeur affiche l'arme associé
        string value = www.downloadHandler.text;

        switch (value)
        {
            case "boss":
                peutTirerLaser = false;
                alimentAeliminer = "boss";
                LASER1.startColor = Color.white;

                break;
            case "carrot":
                peutTirerLaser = true;
                alimentAeliminer = "carrot";
                Physics.IgnoreLayerCollision(9,10, false);
                LASER1.startColor = orange;
                LASER.startColor = orange;
                //aModifieCarotte = true;
                break;
            case "pizza":
                peutTirerLaser = true;
                alimentAeliminer = "pizza";
                Physics.IgnoreLayerCollision(8, 10, false);
                LASER1.startColor = Color.yellow;
                LASER.startColor = Color.yellow;
                break;
        }
    }

    IEnumerator SetBossTarger()
    {
        string tempURL = "http://192.168.1.12:8080/targetBoss";
        // Lance la requette
        UnityWebRequest www = UnityWebRequest.Get(tempURL);
        yield return www.SendWebRequest();

        // Selon la valeur affiche l'arme associé
        string value = www.downloadHandler.text;

    }

}

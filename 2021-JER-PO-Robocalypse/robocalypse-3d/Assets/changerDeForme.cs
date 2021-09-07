using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class changerDeForme : MonoBehaviour
{
    private ParticleSystem transformation_particles;

    private Sprite ballon;
    private Sprite enclume;
    public Sprite astronauteSprite;
    // private Sprite astronaute;
    private GameObject astronaute;
    private Sprite spriteActuel;
    public BoxCollider boxCollider;

    private string URL = "http://192.168.1.12:8080/f/";

    private SpriteRenderer formeAstronaute;

    // Start is called before the first frame update
    void Start()
    {
        ballon = Resources.Load<Sprite>("formesAstronaute/ballon");
        enclume = Resources.Load<Sprite>("formesAstronaute/enclume");

        astronaute = GameObject.Find("astronaute");
        formeAstronaute = astronaute.GetComponent<SpriteRenderer>();
        /*
        transformation_particles = GameObject.Find("transformation_particles").GetComponent<ParticleSystem>();
        */
        transformation_particles.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteActuel = formeAstronaute.sprite;
        //formeAstronaute.sprite = astronauteSprite;
        StartCoroutine(changeForme());
    }


    IEnumerator changeForme()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;

        if (value == "fBallon")
        {
            astronaute.transform.localScale = new Vector3(0.25f, 0.25f, 0.15f);
            boxCollider.center = new Vector3(0f, 0f, 0f);
            boxCollider.size = new Vector3(5f, 8f, 1f);
            if (spriteActuel.name != "ballon")
            {
                
                formeAstronaute.sprite = ballon;
                //formeAstronaute.size
                transformation_particles.Play();

            }
        } else if(value == "fAnvil")
        {
            astronaute.transform.localScale = new Vector3(0.35f, 0.3f, 0.15f);
            boxCollider.center = new Vector3(0f, 0f, 0f);
            boxCollider.size = new Vector3(5f, 4f, 1f);
            if (spriteActuel.name != "enclume")
            {

                formeAstronaute.sprite = enclume;
                //astronaute.transform.localScale = 
                //formeAstronaute.size = new Vector3(0.5f, 0.5f, 1.2f);
                formeAstronaute.size = new Vector3(10f, 5f, 1f);
                transformation_particles.Play();
            }
        } else if(value == "fHuman")
        {
            boxCollider.center = new Vector3(1.2286f, -2.57f, 0);
            boxCollider.size = new Vector3(7.5537f, 13.44f, 1);
            astronaute.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            if (spriteActuel.name != "astronaute")
            {

                astronaute.transform.position += new Vector3(0f, 1f, 0f);
                formeAstronaute.sprite = astronauteSprite;
                transformation_particles.Play();
            }
        }
        
    }
}

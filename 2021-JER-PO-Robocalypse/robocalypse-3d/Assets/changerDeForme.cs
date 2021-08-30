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

    private string URL = "http://192.168.1.12:8080/f/";

    private SpriteRenderer formeAstronaute;

    // Start is called before the first frame update
    void Start()
    {
        ballon = Resources.Load<Sprite>("formesAstronaute/ballon");
        enclume = Resources.Load<Sprite>("formesAstronaute/enclume");

        astronaute = GameObject.Find("astronaute");
        formeAstronaute = astronaute.GetComponent<SpriteRenderer>();

        transformation_particles = GameObject.Find("transformation_particles").GetComponent<ParticleSystem>();

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
            if (spriteActuel.name != "ballon")
            {
                formeAstronaute.sprite = ballon;
                //formeAstronaute.size
                transformation_particles.Play();

            }
        } else if(value == "fAnvil")
        {
            if (spriteActuel.name != "enclume")
            {
                formeAstronaute.sprite = enclume;
                //astronaute.transform.localScale = 
                //formeAstronaute.size = new Vector3(0.5f, 0.5f, 1.2f);
                //formeAstronaute.size = new Vector3(10f, 5f, 1f);
                transformation_particles.Play();
            }
        } else if(value == "fHuman")
        {
            if (spriteActuel.name != "astronaute")
            {
                formeAstronaute.sprite = astronauteSprite;
                transformation_particles.Play();
            }
        }
        
    }
}

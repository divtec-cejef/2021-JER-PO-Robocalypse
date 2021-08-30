using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class changerDeForme : MonoBehaviour
{
    private Sprite ballon;
    private Sprite enclume;
    public Sprite astronauteSprite;
    // private Sprite astronaute;
    private GameObject astronaute;

    private string URL = "http://192.168.1.12:8080/f/";

    private SpriteRenderer formeAstronaute;

    // Start is called before the first frame update
    void Start()
    {
        ballon = Resources.Load<Sprite>("formesAstronaute/ballon");
        enclume = Resources.Load<Sprite>("formesAstronaute/enclume");

        astronaute = GameObject.Find("astronaute");
        formeAstronaute = astronaute.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

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
            formeAstronaute.sprite = ballon;
        } else if(value == "fAnvil")
        {
            formeAstronaute.sprite = enclume;
        } else if(value == "fHuman")
        {
            formeAstronaute.sprite = astronauteSprite;
        }
    }
}

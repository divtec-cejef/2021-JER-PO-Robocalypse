using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HUDCurrentWeapon : MonoBehaviour
{

    private Image weapon;
    private string URL = "http://192.168.1.12:8080/w/";

    public Sprite wRed;
    public Sprite wBlue;


    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Image>();
        weapon.enabled = true;
        weapon.sprite = wBlue;
    }

    // Update is called once per frame
    void Update () {
        // Lance la requette
        StartCoroutine(ShowWeapon());
    }

    /**
	 * Lance une requette pour récupérer la valeur de l'arme sur le serveur
	 */
    IEnumerator ShowWeapon()
    {
        // Lance la requette
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // Selon la valeur affiche l'arme associé
        string value = www.downloadHandler.text;

        switch (value)
        {
            case "wRed":
                weapon.enabled = true;
                weapon.sprite = wRed;
                break;
            case "wBlue":
                weapon.enabled = true;
                weapon.sprite = wBlue;
                break;
            default:
                weapon.enabled = true;
                weapon.sprite = wBlue;
                break;
        }
        
    }
}

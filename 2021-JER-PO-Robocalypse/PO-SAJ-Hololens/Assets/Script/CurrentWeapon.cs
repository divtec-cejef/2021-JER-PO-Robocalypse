using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CurrentWeapon : MonoBehaviour {

	private Text txtWeapon;
	private string URL = "http://192.168.1.12:8080/w/";

	// Use this for initialization
	void Start () {
		txtWeapon = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		// Lance la requette
		StartCoroutine(showWeapon());
	}

	/**
	 * Lance une requette pour récupérer la valeur de l'arme sur le serveur
	 */
	IEnumerator showWeapon()
    {
        // Lance la requette
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

		// affiche la valeur retourné
		string value = (string)www.downloadHandler.text;

    }
}

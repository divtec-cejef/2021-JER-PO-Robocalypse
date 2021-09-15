using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CurrentBuff1 : MonoBehaviour {

	private Text txtWeapon;
	private string URL = "http://192.168.1.11:8080/b/";

	// Use this for initialization
	void Start()
	{
		txtWeapon = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		// Lance la requette
		StartCoroutine(showBuff());
	}

	/**
	 * Lance une requette pour récupérer la valeur du boost sur le serveur
	 */
	IEnumerator showBuff()
	{
		// Lance la requette
		UnityWebRequest www = UnityWebRequest.Get(URL);
		yield return www.SendWebRequest();

		// affiche la valeur retourné
		string value = (string)www.downloadHandler.text;
		txtWeapon.text = "Boost en cours : " + value;

	}
}

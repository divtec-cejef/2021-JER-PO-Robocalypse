using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HUDCurrentBuff : MonoBehaviour
{
     private Image buff;
     private string URL = "http://192.168.1.12:8080/f/";
 
     public Sprite fAnvil;
     public Sprite fHuman;
     public Sprite fBallon;

     // Start is called before the first frame update
     void Start()
     {
         buff = GetComponent<Image>();
     }
 
     // Update is called once per frame
     void Update () {
         // Lance la requette
         StartCoroutine(ShowBuff());
     }
 
     /**
 	 * Lance une requette pour récupérer la valeur de l'arme sur le serveur
 	 */
     IEnumerator ShowBuff()
     {
         // Lance la requette
         UnityWebRequest www = UnityWebRequest.Get(URL);
         yield return www.SendWebRequest();
 
         // Selon la valeur affiche le boost associé
         string value = www.downloadHandler.text;
        
         switch (value)
         {
             case "fAnvil":
                 buff.sprite = fAnvil;
                 break;
             case "fHuman":
                 buff.sprite = fHuman;
                 break;
             case "fBallon":
                 buff.sprite = fBallon;
                 break;
         }
 
     }
}

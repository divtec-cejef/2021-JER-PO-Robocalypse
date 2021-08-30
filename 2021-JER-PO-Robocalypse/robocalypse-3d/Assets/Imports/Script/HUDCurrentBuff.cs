using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HUDCurrentBuff : MonoBehaviour
{
     private Image forme;
     private string URL = "http://192.168.1.12:8080/f";
 
     public Sprite fBallon;
     public Sprite fAnvil;
     public Sprite fHuman;
 
     // Start is called before the first frame update
     void Start()
     {
         forme = GetComponent<Image>();
     }
 
     // Update is called once per frame
     void Update () {
         // Lance la requette
         StartCoroutine(ShowForme());
     }
 
     /**
 	 * Lance une requette pour récupérer la valeur de l'arme sur le serveur
 	 */
     IEnumerator ShowForme()
     {
         // Lance la requette
         UnityWebRequest www = UnityWebRequest.Get(URL);
         yield return www.SendWebRequest();
 
         // Selon la valeur affiche le boost associé
         string value = www.downloadHandler.text;
        
         switch (value)
         {
             case "fBallon":
                forme.enabled = true;
                 forme.sprite = fBallon;
                 break;
             case "fHuman":
                forme.enabled = true;
                forme.sprite = fHuman;
                 break;
             case "fAnvil":
                forme.enabled = true;
                forme.sprite = fAnvil;
                 break;
            default:
                forme.enabled = false;
                break;
         }
 
     }
}

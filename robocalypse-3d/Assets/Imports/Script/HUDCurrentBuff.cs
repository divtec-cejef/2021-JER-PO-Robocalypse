using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HUDCurrentBuff : MonoBehaviour
{
     private Image buff;
     private string URL = "http://192.168.1.11:8080/b/";
 
     public Sprite bJump;
     public Sprite bShield;
     public Sprite bPower;
     public Sprite bSpeed;
 
 
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
             case "bJump":
                 buff.sprite = bJump;
                 break;
             case "bSpeed":
                 buff.sprite = bSpeed;
                 break;
             case "bPower":
                 buff.sprite = bPower;
                 break;
             case "bShield":
                 buff.sprite = bShield;
                 break;
         }
 
     }
}

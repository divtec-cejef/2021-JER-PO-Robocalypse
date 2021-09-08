// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class TapResponderWeaponBuff : MonoBehaviour, IInputClickHandler
    {

        private Renderer renderer;
        private Boolean IsClicked = false;
        private bool loading = false;

        private string URL = "http://192.168.1.12:8080/";
        private string tempURL = "http://192.168.1.12:8080/";

        public bool isWeapon;
        public string value;
        public TextMesh txt;


        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            // gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;

            if (!IsClicked)
            {
                IsClicked = true;
                StartCoroutine(SendValue());
                StartCoroutine(ChangeColorTime());
            }

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        /**
         * Change la couleur du cube et attend 0.5 seconde avant de le
         * rendre de nouveau cliquable
         */
        IEnumerator ChangeColorTime()
        {
            Material mat = GetComponent<Renderer>().material;

            for(int i = 0; i < 3; i++)
            {
                renderer.material.color = Color.clear;

                yield return new WaitForSeconds(0.1f);

                // rend la couleur initial à l'objet

                renderer.material.color = Color.green;

                yield return new WaitForSeconds(0.4f);
            }

            renderer.material.color = Color.white;

            IsClicked = false;
        }

        /**
         * Envoie une requette pour changer la valeur de l'arme ou du boost
         */
        IEnumerator SendValue()
        {
            // Construit l'URL 
            tempURL = URL;
            if (isWeapon)
            {
                tempURL += "w";
            }
            else
            {
                tempURL += "target";
            }
            tempURL += value + "/";

            // Lance la requette
            UnityWebRequest www = UnityWebRequest.Get(tempURL);
            yield return www.SendWebRequest();

            // affiche la valeur retourné
            print((string)www.downloadHandler.text);

            // Ancienne méthode car un peu plus lente
            /*
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                txt.text = www.error;
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                print(www.downloadHandler.text);
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
            */


        }
    }
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HoloToolkit.Unity.InputModule.Tests
{ 
public class TapPractice : MonoBehaviour, IInputClickHandler
    {

        private Renderer renderer;
        private Boolean IsClicked = false;

        private string URL = "http://192.168.1.12:8080/isReady";

        int nbreClics = 0;

        public Text txt_nbreClics; 



        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<Renderer>();
            nbreClics = 0;
            //txt_nbreClics = GameObject.Find("txt_nbreCLics");
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            // gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;

            if (!IsClicked)
            {
                IsClicked = true;
                nbreClics++;
                txt_nbreClics.text = nbreClics + "/3";
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

            for (int i = 0; i < 3; i++)
            {
                renderer.material.color = Color.clear;

                yield return new WaitForSeconds(0.1f);

                // rend la couleur initial à l'objet

                renderer.material.color = Color.green;

                yield return new WaitForSeconds(0.4f);
            }

            renderer.material.color = Color.white;

            IsClicked = false;

            if (nbreClics == 3)
            {
                StartCoroutine(isReady());
                // erreurs au lancement de cette ligne
                SceneManager.LoadScene("InputTapTest");
            }
        }


        IEnumerator isReady()
        {
            UnityWebRequest www = UnityWebRequest.Get(URL);
            yield return www.SendWebRequest();

            // affiche la valeur retourné
            string value = (string)www.downloadHandler.text;
        }

    }
}

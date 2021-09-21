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


        int nbreClics = 0;

        public Text txt_nbreClics;

        private string gameStateValue;

        // Objet du plan de jeu
        public GameObject pizza;
        public GameObject carrot;
        public GameObject red;
        public GameObject blue;

        // Objet du tutoriel
        public GameObject panel;
        public GameObject cible;

        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<Renderer>();
            nbreClics = 0;
            StartCoroutine(gameState());
            //txt_nbreClics = GameObject.Find("txt_nbreCLics");
        }

        void Update()
        {
            StartCoroutine(gameState());
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
                print(StartCoroutine(gameState()));
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

            if (nbreClics >= 3)
            {
                nbreClics = 0;
                txt_nbreClics.text = nbreClics + "/3";

                if (gameStateValue == "fini")
                {
                    StartCoroutine(isNotReady());
                    afficheTutoriel();
                } else if (gameStateValue == "pas commencé" || gameStateValue == "commencé")
                {
                    StartCoroutine(isReady());
                    afficheJeu();
                }


                // erreurs au lancement de cette ligne
                //SceneManager.LoadScene("InputTapTest");
            }
        }


        IEnumerator isReady()
        {
            string URLIsReady = "http://192.168.1.12:8080/isReady";

            UnityWebRequest www = UnityWebRequest.Get(URLIsReady);
            yield return www.SendWebRequest();

            // affiche la valeur retourné
            string value = (string)www.downloadHandler.text;
        }

        IEnumerator isNotReady()
        {
            string URLIsNotReady = "http://192.168.1.12:8080/isNotReady";

            UnityWebRequest www = UnityWebRequest.Get(URLIsNotReady);
            yield return www.SendWebRequest();

            // affiche la valeur retourné
            string value = (string)www.downloadHandler.text;
        }

        IEnumerator gameState()
        {
            string URLGameState = "http://192.168.1.12:8080/game";

            UnityWebRequest www = UnityWebRequest.Get(URLGameState);
            yield return www.SendWebRequest();
            
            gameStateValue = (string)www.downloadHandler.text;
        }

        void afficheJeu()
        {
            red.SetActive(true);
            blue.SetActive(true);
            pizza.SetActive(true);
            carrot.SetActive(true);
            

            panel.SetActive(false);
            cible.SetActive(false);
        }

        void afficheTutoriel()
        {
            red.SetActive(false);
            blue.SetActive(false);
            pizza.SetActive(false);
            carrot.SetActive(false);


            panel.SetActive(true);
            cible.SetActive(true);
        }
    }
}

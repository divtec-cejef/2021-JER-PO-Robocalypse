using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public static bool timerIsRunning = false;
    public TMPro.TextMeshProUGUI timeText;
    public TextMeshProUGUI score;
    private string URL = "http://192.168.1.12:8080/gameIsOver";

    private ParticleSystem CARROT;
    private ParticleSystem TOMATO;
    private ParticleSystem PIZZA;
    private ParticleSystem BOOM;
    private ParticleSystem SMOKE;

    private bool isSmoking = false;
    private bool isCountdown = false;

    public Renderer renderer;

    public Animator animator;
    private bool animationFin = false;

    private SpriteRenderer visageBoss;
    private Sprite visageBossFin;

    private Animator transition;

    public AudioClip sound;
    public AudioClip sound2;

    private void Start()
    {

        transition = GameObject.Find("fermeture").GetComponent<Animator>();
        transition.enabled = false;

        visageBossFin = Resources.Load<Sprite>("boss/visages/visage jaune");
        visageBoss = GameObject.FindWithTag("expressionBoss").GetComponent<SpriteRenderer>();

        // Starts the timer automatically
        timerIsRunning = true;

        CARROT = GameObject.Find("BOUM CARROT").GetComponent<ParticleSystem>();
        CARROT.Stop();

        TOMATO = GameObject.Find("BOUM TOMATO").GetComponent<ParticleSystem>();
        TOMATO.Stop();

        PIZZA = GameObject.Find("BOUM PIZZA").GetComponent<ParticleSystem>();
        PIZZA.Stop();

        SMOKE = GameObject.Find("SMOKE").GetComponent<ParticleSystem>();
        SMOKE.Stop();

        BOOM = GameObject.Find("BOUM").GetComponent<ParticleSystem>();
        BOOM.Stop();

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {

                timerIsRunning = false;
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                
                StartCoroutine(finalDance());

                
            }
            if (timeRemaining <= 45 && !isSmoking)
            {
                AudioSource.PlayClipAtPoint(sound, transform.position);

                SMOKE.Play();
                BOOM.Play();

                isSmoking = true;
            }
            if (timeRemaining <= 10 && !isCountdown)
            {
                print("YEET");
                AudioSource.PlayClipAtPoint(sound2, transform.position);

                isCountdown = true;
            }
        }

        if (animationFin)
        {

            SceneManager.LoadScene("Scenes/Scene_Main");
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
  

    IEnumerator finalDance()
    {

        animator.Play("static_fly_1");
        visageBoss.sprite = visageBossFin;
        yield return StartCoroutine(wait(5f));

        SMOKE.Stop();
        AudioSource.PlayClipAtPoint(sound, transform.position);
        BOOM.Play();
        StartCoroutine(clignoterBoss());
        yield return StartCoroutine(wait(2f));
        AudioSource.PlayClipAtPoint(sound, transform.position);
        BOOM.Play();

        yield return StartCoroutine(wait(2f));
        AudioSource.PlayClipAtPoint(sound, transform.position);
        CARROT.Play();
        PIZZA.Play();
        TOMATO.Play();
        BOOM.Play();

        yield return StartCoroutine(wait(0.5f));
        AudioSource.PlayClipAtPoint(sound, transform.position);
        BOOM.Play();
        BOOM.Play();
        BOOM.Play();
        yield return StartCoroutine(wait(5f));

        /*CARROT.Play();
        BOOM.Play();

        yield return StartCoroutine(wait(2f));

        PIZZA.Play();
        BOOM.Play();

        yield return StartCoroutine(wait(2f));

        TOMATO.Play();
        BOOM.Play();

        yield return StartCoroutine(wait(2f));*/

        transition.enabled = true;
        transition.Play("transition_rond_start");

        yield return StartCoroutine(wait(2f));

        animationFin = true;


        animationFin = true;

        InformationJoueur.scoreEquipe = int.Parse(score.text);
        StartCoroutine(gameIsOver());

    }

    IEnumerator wait(float temps)
    {
        yield return new WaitForSeconds(temps);
    }

    IEnumerator clignoterBoss()
    {

        for (int i = 0; i < 10; i++)
        {
            renderer.enabled = false;
            visageBoss.enabled = false;
            yield return new WaitForSeconds(0.2f);

            renderer.enabled = true;
            visageBoss.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        
        renderer.enabled = false;
        visageBoss.enabled = false;
    }

    IEnumerator gameIsOver()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // affiche la valeur retourné
        string value = (string)www.downloadHandler.text;
        
    }

}
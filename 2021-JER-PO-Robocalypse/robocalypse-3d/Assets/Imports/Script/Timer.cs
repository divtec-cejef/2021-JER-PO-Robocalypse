using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public static bool timerIsRunning = false;
    public TMPro.TextMeshProUGUI timeText;
    public TextMeshProUGUI score;

    private ParticleSystem CARROT;
    private ParticleSystem TOMATO;
    private ParticleSystem PIZZA;
    private ParticleSystem BOOM;

    public Renderer renderer;

    public Animator animator;
    private bool animationFin = false;

    private SpriteRenderer visageBoss;
    private Sprite visageBossFin;

    private void Start()
    {
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
                InformationJoueur.scoreEquipe = int.Parse(score.text);
                Debug.Log("Time has run out!");
                timeRemaining = 0;

                StartCoroutine(finalDance());

                
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

        BOOM.Play();
        StartCoroutine(clignoterBoss());
        yield return StartCoroutine(wait(2f));

        BOOM.Play();

        yield return StartCoroutine(wait(2f));

        CARROT.Play();
        PIZZA.Play();
        TOMATO.Play();
        BOOM.Play();

        yield return StartCoroutine(wait(0.5f));
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

        animationFin = true;


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
}
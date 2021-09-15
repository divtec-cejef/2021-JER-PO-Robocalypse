using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBackground : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite pingouinOuvert;
    public Sprite pingouinFermer;

    private bool backgroundChanging = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkBackground();
    }

    void checkBackground()
    {
        if (!(backgroundChanging))
        {
            StartCoroutine(background());
            backgroundChanging = true;
        }
    }

    IEnumerator background()
    {
        yield return StartCoroutine(changeBackground());
        backgroundChanging = false;
    }

    IEnumerator changeBackground()
    {
        spriteRenderer.sprite = pingouinFermer;

        yield return new WaitForSeconds(0.5f);

        spriteRenderer.sprite = pingouinOuvert;


        yield return new WaitForSeconds(3.5f);

    }
}

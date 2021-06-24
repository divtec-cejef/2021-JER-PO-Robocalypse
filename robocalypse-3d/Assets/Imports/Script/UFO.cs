using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class UFO : MonoBehaviour
{
    public GameObject player;


    private Vector3 choix;
    private Vector3 ancien;

    // Où l'UFO se déplacera la prochaine fois
    // private Vector3 futurePosition;
    Vector3[] positionsPossibles = {(new Vector3(-0.8f, 0.9f, 0.2f)),
        (new Vector3(0.8f,1.2f,0.2f)),
        (new Vector3(1f,0.4f,0.2f)),
        (new Vector3(-1f,0.2f,0.2f))};

    private Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        choix = positionsPossibles[0];
        // UFOposition();
        // StartCoroutine(wait());
        InvokeRepeating(nameof(UFOposition), .1f, 2f);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // lévitation
        Vector3 posOffset = new Vector3 ();
        Vector3 tempPos = new Vector3 ();
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * 3f) * 0.1f; // fréquence, amplitude
        
        position = player.transform.position;
 
        transform.position = tempPos;
        
        transform.position = position + choix + tempPos; // + choix au lieu de tempPos
        
    }

    void UFOposition()
    {
        int rand = Random.Range(0, positionsPossibles.Length);
        
        choix = positionsPossibles[rand];
        if (choix == ancien)
        {
            choix = positionsPossibles[rand];
        }

        ancien = choix;
        Debug.Log("position changée");
        
    }

   
    /*IEnumerator wait()
    {
            // position = player.transform.position;
            int rand = Random.Range(0, positionsPossibles.Length);

            yield return new WaitForSeconds(2f);

            Debug.ClearDeveloperConsole();
            transform.position = position + positionsPossibles[rand];

            // transform.position = position + positionsPossibles[1];

            yield return new WaitForSeconds(2f);

            Debug.Log("OK");
        
        
        // transform.position = position + positionsPossibles[1];
        
        // yield return new WaitForSeconds(2);
    }*/

}

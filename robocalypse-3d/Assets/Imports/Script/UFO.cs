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

    private Vector3 position;

    private Vector3[] positionsPossibles = {(new Vector3(-0.3f, 0.8f, 0.1f)), (new Vector3(0.8f,1.5f,0.1f))};
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changePosition());
        // InvokeRepeating("changePosition", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        position = player.transform.position;
        transform.position = position + positionsPossibles[0];
        
        
    }

    /**
     * L'UFO change de position toutes les deux secondes.
     */
    IEnumerator changePosition()
    {
        while (true)
        {
            print("Debut");
        
            int rand = Random.Range(0, positionsPossibles.Length);
        
            transform.position = position + positionsPossibles[rand];
        
            yield return new WaitForSeconds(2f);
            print("FIN");
        }
        

        // yield return new WaitForSeconds(2);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePizza : MonoBehaviour
{

    public Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 180f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "astronaute")
        {
            Destroy(gameObject);
            // décrémenter le score du joueur 
            // faire clignoter le joueur en rouge
        }
        else if (collision.collider.name == "Invisiblewall (2)")
        {
            Destroy(gameObject);
        }
    }
}

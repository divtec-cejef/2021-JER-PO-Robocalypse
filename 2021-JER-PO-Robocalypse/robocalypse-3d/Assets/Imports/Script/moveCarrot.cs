using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCarrot : MonoBehaviour
{
    private Rigidbody rb;

    private int speed;
    //private float horizontalInput;
    //private float verticalInput;
    //private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 500f);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(horizontalInput, 0.0f, verticalInput) * speed);
        rb.AddForce(Vector3.back * 6);
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

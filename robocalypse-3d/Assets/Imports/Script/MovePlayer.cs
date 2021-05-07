using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    
    public float jumph;
    public float jumpForce;
        
    private Vector3 jump;
    private Rigidbody rigg;
    private BoxCollider playerBoxCol;
    private Transform playerTransform;
        
    private bool isGrounded;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        
        jump = new Vector3(0f, jumph, 0f);
        rigg = GetComponent<Rigidbody>();
        playerBoxCol = GetComponent<BoxCollider>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 vertical = new Vector3(0, 0, Input.GetAxis("Vertical"));

        // déplacements G/D, 
        if (move != Vector3.zero)
        {
            gameObject.transform.Translate(bestAxis(horizontal, vertical));
            controller.Move(Time.deltaTime * speed * (bestAxis(horizontal, vertical)));
        }
        
        // déplacements H/B
        if (Input.GetKeyDown("o"))
            {
                playerBoxCol.size = new Vector3(1, 0.5f, 0.5f);
                playerTransform.localScale = new Vector3(1, 0.5f, 1);
            }

            if (Input.GetKeyUp("o"))
            {
                playerBoxCol.size = new Vector3(1, 1, 0.5f);
                playerTransform.localScale = new Vector3(1, 1, 1);
            }
            
            // jump
            if (rigg.velocity.y == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigg.AddForce(jump * jumpForce, ForceMode.Impulse);
                }
            }
    }

    /**
     * Choisit l'axe vertical ou horizontal pour ne pas faire de diagonale.
     */
    Vector3 bestAxis(Vector3 horizontal, Vector3 vertical)
    {
        // déplacement horizontal par défaut
        Vector3 meilleurAxe = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // choix d'un des deux axes possibles
        if (horizontal.magnitude > vertical.magnitude)
        {
            // bloquer l'axe z
            meilleurAxe.z = 0;
        }
        else if (horizontal.magnitude < vertical.magnitude)
        {
            // bloquer l'axe x
            meilleurAxe.x = 0;
        }
        else
        {
            // bloquer l'axe z
            meilleurAxe.z = 0;
        }
        return meilleurAxe;
            
    }
}

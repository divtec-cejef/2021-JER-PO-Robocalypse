using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerAndJump : MonoBehaviour
{
    
    public float speed;
    public bool playerIsOnTheGround = true;
    public bool playerIsSneaking;
    public bool playerCanMove = true;
    
    private BoxCollider playerBoxCol;
    private Transform playerTransform;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        playerBoxCol = GetComponent<BoxCollider>();
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
       PlayerMovement();
    }

    /**
     * Regroupe tous les mouvements que peut faire le joueur
     * il peut avancer, reculer, aller à droite et à gauche et il peut sauter
     */
    private void PlayerMovement()
    {
        // Si le joueur est sur le sol permet au joueur de se déplacer
        if (playerIsOnTheGround) 
        {
            // Si le joueur est en train de se baisser, l'empêche de pouvoir se déplacer
            if (playerIsSneaking)
            {
                if (Input.GetKeyUp("s"))
                {
                    playerIsSneaking = false;
                    playerBoxCol.size = new Vector3(1, 1, 0.5f);
                    playerTransform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                // déplacement haut, bas, gauche & droite
                Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0); 
                Vector3 vertical = new Vector3(0, 0, Input.GetAxis("Vertical")); 

                transform.Translate( Time.deltaTime * speed * BestAxis(horizontal,vertical));
                
                //s'accroupir
                if (Input.GetKeyDown("s"))
                {
                    playerIsSneaking = true;
                    playerBoxCol.size = new Vector3(1, 0.5f, 0.5f);
                    playerTransform.localScale = new Vector3(1, 0.5f, 1);
                }
                
                // le saut
                if (Input.GetButtonDown("Jump") && playerIsOnTheGround)
                {
                    rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
                    playerIsOnTheGround = false;
                    playerCanMove = false;
                }
            }
        }
        // Ancienne code qui prennait en compte le saut du joueur et le temps qu'il se remette sur la wii Board
        /*
        else
        {  
            // Si le joueur ne peut pas se déplacer (après un saut) on attend que le joueur pose un pied sur la wii
            // Board et ensuite on met un petit temps d'attente avant de débloquer les déplacements
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(Wait());           
                playerCanMove = true;
            }
        }
        */
    }
    
    /**
     * Si le joueur est en contact avec un objet qui a le tag Ground, change la valeur de playerisOnGround
     */
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerIsOnTheGround = true;
        }
    }
    
    /**
     * Retourne l'axe dans lequel le joueur doit se déplacer
     * (Pour éviter de faire des diagonales)
     */
    Vector3 BestAxis(Vector3 horizontal, Vector3 vertical)
    {
        // déplacement horizontal par défaut
        Vector3 meilleurAxe = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // choix d'un des deux axes possibles
        meilleurAxe.z = 0;
        
        // permet de bloquer un des axes du personnage (empêche les diagonales)
        /*
        if (horizontal.magnitude > vertical.magnitude) 
        {
            // bloquer l'axe z
            
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
        */
        
        return meilleurAxe;
    }

    /*
     * Rend le joueur lent pour l'empêcher de se déplacer et ensuite lui remet sa vitesse
     * (on met un temps d'attente pour laisser à la personne le temps de remonter sur la Wii Board)
     */
    IEnumerator Wait()
    {
        speed = 0.0001f;
        
        yield return new WaitForSeconds(0.85f);

        speed = 5f;
        playerCanMove = true;
    }
}
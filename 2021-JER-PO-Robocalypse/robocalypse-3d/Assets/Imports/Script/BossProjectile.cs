using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public string nomCible = "Cible";
    public int vitesse = 3;
    
    public Rigidbody rb;
    // public int nbrPointsParSphere = 50;

    // public GameObject messagePoints;
    
    // Start is called before the first frame update
    void Start()
    {
        // messagePoints.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Imports/HUD/score/+1.png");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == nomCible)
        {
            // position du projectile au moment de l'impact
            // Vector3 position = transform.position;
            
            // affichagePoints.transform.position = position;
            // messagePoints = Instantiate(messagePoints, position, Quaternion.identity);
            
            //Destroy this gameobject
            Destroy(gameObject);
            
            // incrémentation points
            // nbrPoints++;

            // Debug.Log(nbrPoints);

            // si la collision est autre que la cible
        } else if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            rb.velocity = new Vector3(0, 0, -(vitesse));
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}

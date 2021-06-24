using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public string nomCible = "InvisibleCube";

    public int nbrPointsParSphere = 50;

    private Text affichagePoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            Vector3 position = transform.position;
            
            // affichagePoints.transform.position = position;
            
            //Destroy this gameobject
            Destroy(gameObject);
            


        } else if (collision.collider.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}

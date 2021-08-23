using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ClignoterJoueur()
    {
        
        Physics.IgnoreLayerCollision(3, 8, true);
        for (int i = 0; i < 5; i++)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);

            renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        
        Physics.IgnoreLayerCollision(3, 8, false);
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("projectilesBoss"))
        {
            // position du projectile au moment de l'impact
            // Vector3 position = transform.position;

            // affichagePoints.transform.position = position;
            // messagePoints = Instantiate(messagePoints, position, Quaternion.identity);

            //Destroy this gameobject
            StartCoroutine(ClignoterJoueur());

            // incrémentation points
            // nbrPoints++;

            // Debug.Log(nbrPoints);

            // si la collision est autre que la cible
        }
    }
}

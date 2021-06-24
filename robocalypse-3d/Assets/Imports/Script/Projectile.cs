using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string nomCible = "Sphere";
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
        if (collision.collider.name == "InvisibleCube")
        {
            //Destroy this gameobject
            Destroy(gameObject);

        } else if (collision.collider.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}

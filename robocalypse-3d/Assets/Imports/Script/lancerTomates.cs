using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class lancerTomates : MonoBehaviour
{
    public GameObject alimentAInstancier;

    private Vector3 positionTomate;

    private Vector3[] positionsTuiles =
    {
        (new Vector3(-4.14f, 17, 9.62f)), 
        (new Vector3(-2.2f, 17, 9.62f)),
        (new Vector3(-0.2f, 17, 9.62f)),
        (new Vector3(1.79f, 17, 9.62f)),
        (new Vector3(3.79f, 17, 9.62f))
    };
    
    // Start is called before the first frame update
    void Start()
    {
        /*if (alimentAInstancier)
        {
            alimentAInstancier = GameObject.Find("Tomate");
            print("non");
        }*/
        InvokeRepeating("apparitionTomate", 1f, 7f);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        

        
    }
    void apparitionTomate()
    {
        int rand = Random.Range(0, positionsTuiles.Length);

        Vector3 positionDepartProjectiles = positionsTuiles[rand];

        // Création d'une instance de projectile
        GameObject tomate = Instantiate(alimentAInstancier, positionDepartProjectiles, Quaternion.identity) as GameObject;

        tomate.GetComponent<Rigidbody>().useGravity = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class projectilesBoss : MonoBehaviour
{
    public GameObject alimentAInstancier;

    private GameObject modeleCarotte;

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
        modeleCarotte = GameObject.Find("carrot");
        /*if (alimentAInstancier)
        {
            alimentAInstancier = GameObject.Find("Tomate");
            print("non");
        }*/
        // InvokeRepeating("ApparitionTomate", 1f, 7f);
        // InvokeRepeating("ApparitionCarotte", 2f, 7f);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        

        
    }
    void ApparitionTomate()
    {
        int rand = Random.Range(0, positionsTuiles.Length);

        Vector3 positionDepartProjectiles = positionsTuiles[rand];

        // Création d'une instance de projectile
        GameObject tomate = Instantiate(alimentAInstancier, positionDepartProjectiles, Quaternion.identity) as GameObject;

        tomate.GetComponent<Rigidbody>().useGravity = true;

    }

    void ApparitionCarotte()
    {
        Vector3 positionDepartCarotte = new Vector3(-0.17f, 17, 9.62f);
        
        // création d'une carotte
        GameObject carotte = Instantiate(modeleCarotte, positionDepartCarotte, Quaternion.identity);
        
        carotte.transform.Rotate(new Vector3(0, 0, 90));

        carotte.GetComponent<Rigidbody>().useGravity = true;
    }

    void ApparitionPizza()
    {
        
    }
}

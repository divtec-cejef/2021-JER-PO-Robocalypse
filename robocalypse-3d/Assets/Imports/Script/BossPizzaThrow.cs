using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPizzaThrow : MonoBehaviour
{
    private GameObject projectile;
    public float vitesse = 5;
    public Vector3 direction;

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

    void ShootProjectile()
    {
        // décalage du départ des projectiles
        Vector3 positionDepartProjectiles;


        
        switch (Random.Range(1,5))
        {
            case(1):
                positionDepartProjectiles = new Vector3(-4.12f, 1.878f, 10.44f);
                break;
            case(2):
                positionDepartProjectiles = new Vector3(-2.17f, 1.878f, 10.44f);
                break;
            case(3):
                positionDepartProjectiles = new Vector3(-0.15f, 1.878f, 10.44f);
                break;
            case(4):
                positionDepartProjectiles = new Vector3(1.82f, 1.878f, 10.44f);
                break;
            case(5):
                positionDepartProjectiles = new Vector3(3.82f, 1.878f, 10.44f);
                break;
            default:
                positionDepartProjectiles = new Vector3(-0.15f, 1.878f, 10.44f);
                break;
        }

        Vector3 positionHorsChamp = new Vector3(positionDepartProjectiles.x, positionDepartProjectiles.y + 10,
            positionDepartProjectiles.z);

        
        // définition direction projectiles
        direction = new Vector3(0f, 0f, -(vitesse));
        
        // Création d'une instance de projectile
        GameObject pizza = Instantiate(projectile, positionDepartProjectiles, Quaternion.identity) as GameObject;
        // Le projectile se déplace jusqu'à sa cible
        pizza.GetComponent<Rigidbody>().velocity = direction;
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

    
    private void Start()
    {
        projectile = GameObject.Find("pizza");
        InvokeRepeating("ShootProjectile",1,5);
    }

}

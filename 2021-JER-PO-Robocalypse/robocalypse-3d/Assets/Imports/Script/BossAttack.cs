using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    private GameObject projectile;
    public float vitesse = 5;
    public Vector3 direction;

    private GameObject modelePizza;

    private GameObject modeleTomate;

    private GameObject modeleCarotte;

    private Vector3 positionTomate;

    private int ancienRandTomate;
    private int ancienRandPizza;

    private Vector3[] positionsTuiles =
    {
        (new Vector3(-4.14f, 17, 9.62f)),
        (new Vector3(-2.2f, 17, 9.62f)),
        (new Vector3(-0.2f, 17, 9.62f)),
        (new Vector3(1.79f, 17, 9.62f)),
        (new Vector3(3.79f, 17, 9.62f))
    };

    public Animator animator;


    void ApparitionPizza()
    {

        // décalage du départ des projectiles
        Vector3 positionDepartProjectiles;
        int rand = Random.Range(1, 5);

        while (rand == ancienRandPizza)
        {
            rand = Random.Range(1, 5);

        }


        switch (rand)
        {
            case (1):
                positionDepartProjectiles = new Vector3(-4.12f, 1.878f, 10.44f);
                break;
            case (2):
                positionDepartProjectiles = new Vector3(-2.17f, 1.878f, 10.44f);
                break;
            case (3):
                positionDepartProjectiles = new Vector3(-0.15f, 1.878f, 10.44f);
                break;
            case (4):
                positionDepartProjectiles = new Vector3(1.82f, 1.878f, 10.44f);
                break;
            case (5):
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
        GameObject pizza = Instantiate(modelePizza, positionDepartProjectiles, Quaternion.identity) as GameObject;
        // Le projectile se déplace jusqu'à sa cible
        pizza.GetComponent<Rigidbody>().velocity = direction;

        ancienRandPizza = rand;
    }

    void ApparitionTomate()
    {
        int rand = Random.Range(0, positionsTuiles.Length);

        // vérification doublons
        while (ancienRandTomate == rand)
        {
            rand = Random.Range(0, positionsTuiles.Length);
        }

        Vector3 positionDepartProjectiles = positionsTuiles[rand];

        // Création d'une instance de projectile
        GameObject tomate = Instantiate(modeleTomate, positionDepartProjectiles, Quaternion.identity) as GameObject;

        tomate.GetComponent<Rigidbody>().useGravity = true;

        ancienRandTomate = rand;

    }

    private void ApparitionCarotte()
    {
        Vector3 positionDepartCarotte = new Vector3(-0.17f, 17, 9.62f);

        // création d'une carotte
        GameObject carotte = Instantiate(modeleCarotte, positionDepartCarotte, Quaternion.identity);

        carotte.transform.Rotate(new Vector3(0, 0, 90));

        carotte.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator AnimationCarotte()
    {
        animator.Play("throw_carrot");
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator LancerDeCarotte()
    {
        yield return StartCoroutine(AnimationCarotte());
        ApparitionCarotte();
        animator.Play("static_fly_1");
    }

    IEnumerator AnimationTomate()
    {
        animator.Play("throw_tomato");
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator LancerDeTomate()
    {

        yield return StartCoroutine(AnimationTomate());
        ApparitionTomate();
        animator.Play("static_fly_1");
    }

    IEnumerator AnimationPizza()
    {
        animator.Play("throw_pizza");
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator LancerDePizza()
    {

        yield return StartCoroutine(AnimationPizza());
        ApparitionPizza();
        animator.Play("static_fly_1");
    }

    void SchemaAttaque()
    {
        switch (Random.Range(0, 3))
        {
            case 0:

                StartCoroutine(LancerDeTomate());

                break;
            case 1:

                StartCoroutine(LancerDeCarotte());

                break;
            case 2:

                StartCoroutine(LancerDePizza());

                break;

        }
    }

    private void lancerPizzaXFois(int nbrFois)
    {
        for (int i = 0; i < nbrFois; i++)
        {
            //Invoke("ApparitionTomate", 1f);
            StartCoroutine(LancerDePizza());


        }
    }

    private void lancerTomateXFois(int nbrFois)
    {
        for (int i = 0; i < nbrFois; i++)
        {
            //Invoke("ApparitionTomate", 1f);
            StartCoroutine(LancerDeTomate());


        }
    }



    // Start is called before the first frame update
    void Start()
    {
        modeleCarotte = GameObject.Find("carrot");
        modeleTomate = GameObject.Find("Tomate");
        modelePizza = GameObject.Find("pizza");

        // Invoke("SchemaAttaque", 1);


        // InvokeRepeating("SchemaAttaque", 1, 5f);

        /**InvokeRepeating("LancerDeTomate", 1, 5);
               Invoke("LancerDeTomate", 1f);
               Invoke("LancerDeTomate", 1f);
               Invoke("LancerDeTomate", 1f);
               */
        lancerTomateXFois(4);

        // StartCoroutine(LancerXFois());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

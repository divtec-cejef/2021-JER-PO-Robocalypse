using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private ParticleSystem tomato_particles;

    private GameObject projectile;
    public float vitesse = 5;
    public Vector3 direction;

    //private ParticleSystem pizza_particles;
    

    private GameObject modelePizza;

    private GameObject modeleTomate;

    private GameObject modeleCarotte;

    private Vector3 positionTomate;

    private int ancienRandAliment;
    
    //private ArrayList anciensRandTomates = new ArrayList(){1, 2, 3, 4};

    /*
    private int ancienRandPizza;
    private int ancienRandPizza;
    private int ancienRandPizza;
    private int ancienRandPizza;
    private int ancienRandPizza;
    */
   // private ArrayList anciensRandPizzas = new ArrayList(){ 1, 2, 3, 4, 5};

    

    private ArrayList positionsTuiles = new ArrayList()
    {
        (new Vector3(-4.14f, 17, 9.62f)),
        (new Vector3(-2.2f, 17, 9.62f)), // 17
        (new Vector3(-0.2f, 17, 9.62f)),
        (new Vector3(1.79f, 17, 9.62f)),
        (new Vector3(3.79f, 17, 9.62f))
    };

    ArrayList positionsPizzas = new ArrayList()
        {
            (new Vector3(-4.12f, 1.870f, 10.44f)), // 1.878F pour tous
            (new Vector3(-2.17f, 1.870f, 10.44f)),
            (new Vector3(-0.15f, 1.870f, 10.44f)),
            (new Vector3(1.82f, 1.870f, 10.44f)),
            (new Vector3(3.82f, 1.870f, 10.44f)),
            (new Vector3(-0.15f, 1.870f, 10.44f))
        };


    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        /*pizza_particles = GameObject.Find("pizza_pizza_particles").GetComponent<ParticleSystem>();
        pizza_particles.Stop();*/

        modeleCarotte = GameObject.Find("carrot");
        modeleTomate = GameObject.Find("Tomate");
        modelePizza = GameObject.Find("pizza");

        // Invoke("SchemaAttaque", 1);
        tomato_particles = GameObject.Find("tomato_particles").GetComponent<ParticleSystem>();

        tomato_particles.Stop(); // ne marche pas

        InvokeRepeating("SchemaAttaque", 1, 5f);

    }

    void ApparitionPizza()
    {

        // décalage du départ des projectiles
        Vector3 positionDepartProjectiles;

        int rand = Random.Range(0, positionsTuiles.Count - 1);


        positionDepartProjectiles = (Vector3)positionsPizzas[rand];

        
        /*
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
        }*/

        Vector3 positionHorsChamp = new Vector3(positionDepartProjectiles.x, positionDepartProjectiles.y + 10,
            positionDepartProjectiles.z);


        // définition direction projectiles
        direction = new Vector3(0f, 0f, -(vitesse));

        // Création d'une instance de projectile
        GameObject pizza = Instantiate(modelePizza, positionDepartProjectiles, Quaternion.identity) as GameObject;


        // Le projectile se déplace jusqu'à sa cible
        // VITESSE
        pizza.GetComponent<Rigidbody>().velocity = direction * 0.5f;

        if (positionsPizzas.Count != 0)
        {
            positionsPizzas.RemoveAt(rand);

        }

    }

    void ApparitionTomate()
    {
        int rand = Random.Range(0, positionsTuiles.Count - 1);


        Vector3 positionDepartProjectiles = (Vector3)positionsTuiles[rand] - new Vector3(0, 0.4f, 0);

        // Création d'une instance de projectile
        
        GameObject tomate = Instantiate(modeleTomate, positionDepartProjectiles, Quaternion.identity) as GameObject;
        

        positionsTuiles.RemoveAt(rand);

        // tomate.GetComponent<Rigidbody>().useGravity = true;

        

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
        animator.Play("static_fly_2");
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
        animator.Play("static_fly_2");
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
        animator.Play("static_fly_2");
    }

    void SchemaAttaque()
    {
        // ne pas répéter deux fois de suite le même aliment 
        int rand;

        do
        {
            rand = Random.Range(0, 4);
        } while (rand == ancienRandAliment);
       
        if (Timer.timerIsRunning)
        {
            switch (rand)
            {
                case 0:

                    // StartCoroutine(LancerDeTomate());
                    lancerTomateXFois(Random.Range(2, 4));

                    // réinitialisation
                    positionsTuiles = new ArrayList()
                    {
                        (new Vector3(-4.14f, 17, 9.62f)),
                        (new Vector3(-2.2f, 17, 9.62f)),
                        (new Vector3(-0.2f, 17, 9.62f)),
                        (new Vector3(1.79f, 17, 9.62f)),
                        (new Vector3(3.79f, 17, 9.62f))
                    };

                    break;
                case 1:

                    StartCoroutine(LancerDeCarotte());

                    ancienRandAliment = rand;

                    break;
                case 2:

                    // StartCoroutine(LancerDePizza());
                    lancerPizzaXFois(Random.Range(3, 5));
                    ancienRandAliment = rand;

                    // réinitialisation
                    /*positionsPizzas = new ArrayList()
                        {
                            (new Vector3(-4.12f, 1.878f, 10.44f)),
                            (new Vector3(-2.17f, 1.878f, 10.44f)),
                            (new Vector3(-0.15f, 1.878f, 10.44f)),
                            (new Vector3(1.82f, 1.878f, 10.44f)),
                            (new Vector3(3.82f, 1.878f, 10.44f)),
                            (new Vector3(-0.15f, 1.878f, 10.44f))
                        };
                        */

                    break;
                case 3:
                    // StartCoroutine(LancerDeTomate());
                    lancerTomateXFois(Random.Range(2, 4));

                    // réinitialisation
                    positionsTuiles = new ArrayList()
                    {
                        (new Vector3(-4.14f, 17, 9.62f)),
                        (new Vector3(-2.2f, 17, 9.62f)),
                        (new Vector3(-0.2f, 17, 9.62f)),
                        (new Vector3(1.79f, 17, 9.62f)),
                        (new Vector3(3.79f, 17, 9.62f))
                    };

                    break;
                case 4:
                    // StartCoroutine(LancerDeTomate());
                    lancerTomateXFois(Random.Range(2, 4));

                    // réinitialisation
                    positionsTuiles = new ArrayList()
                    {
                        (new Vector3(-4.14f, 17, 9.62f)),
                        (new Vector3(-2.2f, 17, 9.62f)),
                        (new Vector3(-0.2f, 17, 9.62f)),
                        (new Vector3(1.79f, 17, 9.62f)),
                        (new Vector3(3.79f, 17, 9.62f))
                    };

                    break;
                default:
                    // StartCoroutine(LancerDeTomate());
                    lancerTomateXFois(Random.Range(2, 4));

                    // réinitialisation
                    positionsTuiles = new ArrayList()
                    {
                        (new Vector3(-4.14f, 17, 9.62f)),
                        (new Vector3(-2.2f, 17, 9.62f)),
                        (new Vector3(-0.2f, 17, 9.62f)),
                        (new Vector3(1.79f, 17, 9.62f)),
                        (new Vector3(3.79f, 17, 9.62f))
                    };

                    break;

            }
        }
        

        // ancienRandAliment = rand;
        
    }

    private void lancerPizzaXFois(int nbrFois)
    {
        // réinitialisation
        positionsPizzas = new ArrayList()
                    {
                        (new Vector3(-4.12f, 1.878f, 10.44f)),
                        (new Vector3(-2.17f, 1.878f, 10.44f)),
                        (new Vector3(-0.15f, 1.878f, 10.44f)),
                        (new Vector3(1.82f, 1.878f, 10.44f)),
                        (new Vector3(3.82f, 1.878f, 10.44f)),
                        (new Vector3(-0.15f, 1.878f, 10.44f))
                    };
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



    

    // Update is called once per frame
    void Update()
    {

    }
}

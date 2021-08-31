using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Renderer renderer;

    public ParticleSystem tomato_particles;
    private ParticleSystem carrot_particles;
    private ParticleSystem pizza_particles;

    private RippleProcess camRipple;

    // Start is called before the first frame update
    void Start()
    {


        carrot_particles = GameObject.Find("carrot_particles").GetComponent<ParticleSystem>();
        pizza_particles = GameObject.Find("pizza_particles").GetComponent<ParticleSystem>();

        tomato_particles.Stop();
        carrot_particles.Stop();
        pizza_particles.Stop();

        camRipple = Camera.main.GetComponent<RippleProcess>();
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
            if (collision.gameObject.name == "pizza(Clone)")
            {
                pizza_particles.Play();
            }
            else if (collision.gameObject.name == "Tomate(Clone)")
            {
                tomato_particles.Play();
            }
            else if (collision.gameObject.name == "carrot(Clone)")
            {
                carrot_particles.Play();
            }
            camRipple.RippleEffect();
            StartCoroutine(ClignoterJoueur());

          
            // incrémentation points
            // nbrPoints++;

            // Debug.Log(nbrPoints);

            // si la collision est autre que la cible
        }
    }
}

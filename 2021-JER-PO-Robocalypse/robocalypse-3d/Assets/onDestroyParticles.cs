using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDestroyParticles : MonoBehaviour
{
    private ParticleSystem pizza_particles;
    private GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        /*test = this.transform.GetChild(0).gameObject;
        pizza_particles = test.GetComponent<ParticleSystem>();*/
        

        //pizza_particles = GameObject.Find("pizza_particles2").GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //pizza_particles.Play();
    }

    

    void OnDestroy()
    {
        //pizza_particles.Play();
    }
}
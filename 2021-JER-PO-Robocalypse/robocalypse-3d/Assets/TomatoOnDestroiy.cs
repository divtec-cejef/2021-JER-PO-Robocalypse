using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoOnDestroiy : MonoBehaviour
{

    public ParticleSystem tomato_particles;

    // Start is called before the first frame update
    void Start()
    {
        tomato_particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        tomato_particles.Play();
    }
}

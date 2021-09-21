using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class OnDestroyBulletBoss : MonoBehaviour
{
    public AudioClip sound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "astronaute")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}

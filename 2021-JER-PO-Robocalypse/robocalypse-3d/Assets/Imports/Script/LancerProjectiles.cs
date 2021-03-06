using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class LancerProjectiles : MonoBehaviour
{
    private GameObject projectile;

    private string URL = "http://192.168.1.12:8080/w/";

    public GameObject cible;

    public Vector3 direction;

    private GameObject UFO;

    public AudioClip sound;

    IEnumerator ShowWeapon()
    {
        // Lance la requette
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        // Selon la valeur affiche l'arme associé
        string value = www.downloadHandler.text;

        switch (value)
        {
            case "wRed":
                projectile = GameObject.Find("projectile magenta");
                break;
            case "wBlue":
                projectile = GameObject.Find("projectile bleu");
                break;
            case "wYellow":
                projectile = GameObject.Find("projectile jaune");
                break;
            case "wGreen":
                projectile = GameObject.Find("projectile vert");
                break;
            default:
                projectile = GameObject.Find("projectile bleu");
                break;
        }

    }


    void ShootProjectile()
    {
        if (Timer.timerIsRunning && UFO.transform.position.z <= -2.57f)
        {

            // yield return new WaitForSeconds(0.3f);
            Vector3 positionCible = new Vector3(cible.transform.position.x - 1, cible.transform.position.y + 2,
                cible.transform.position.z);

            // décalage du départ des projectiles
            Vector3 positionDepartProjectiles = new Vector3(transform.position.x, transform.position.y /*+ 0.5f*/, transform.position.z + 0.2f);

            // définition direction projectiles
            direction = positionCible - positionDepartProjectiles;

            // Création d'une instance de projectile
            GameObject bullet = Instantiate(projectile, positionDepartProjectiles, Quaternion.identity) as GameObject;

            // Le projectile se déplace jusqu'à sa cible
            bullet.GetComponent<Rigidbody>().AddForce(direction * 50);

            //sound
            AudioSource.PlayClipAtPoint(sound, transform.position, 0.05f);

        }
    }

    private void Start()
    {
        projectile = GameObject.Find("projectile bleu");

        UFO = GameObject.Find("UFO");


        // StartCoroutine(ShootProjectile());
        InvokeRepeating("ShootProjectile", 1f, .15f);// .09
        // InvokeRepeating("ShowWeapon", 0f, .01f);
    }

    private void Update()
    {
        StartCoroutine(ShowWeapon());

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject bullet = Instantiate(projectile, transform.position + calibrationPositionJoueur, Quaternion.identity) as GameObject;
            
            
        }
        */
    }
}

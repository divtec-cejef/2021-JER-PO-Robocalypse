using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LancerProjectiles : MonoBehaviour
{
    public GameObject projectile;

    public GameObject cible;

    public Vector3 direction;

    private Vector3 calibrationPositionJoueur;
    
    void ShootProjectile()
    {
        // yield return new WaitForSeconds(0.3f);
        Vector3 positionCible = new Vector3(cible.transform.position.x, cible.transform.position.y,
            cible.transform.position.z);
        
        // direction = new Vector3(direction.x, 2f, direction.z);
        
        
        // décalage du départ des projectiles
        Vector3 positionDepartProjectiles = new Vector3 (transform.position.x - 0.5f, 0.5f, transform.position.z);
        
        // définition direction projectiles
        direction = positionCible - positionDepartProjectiles;
        
        // Création d'une instance de projectile
        GameObject bullet = Instantiate(projectile, positionDepartProjectiles, Quaternion.identity) as GameObject;
        
        // Le projectile se déplace jusqu'à sa cible
        bullet.GetComponent<Rigidbody>().AddForce(direction * 50);

    }

    private void Start()
    {
        // StartCoroutine(ShootProjectile());
        InvokeRepeating("ShootProjectile", 1f, .09f);
    }

    private void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject bullet = Instantiate(projectile, transform.position + calibrationPositionJoueur, Quaternion.identity) as GameObject;
            
            
        }
        */
    }

   

    }

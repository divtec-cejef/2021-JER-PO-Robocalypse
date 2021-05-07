using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 vertical = new Vector3(0, 0, Input.GetAxis("Vertical"));

        if (move != Vector3.zero)
        {
            gameObject.transform.Translate(bestAxis(horizontal, vertical));
            controller.Move(Time.deltaTime * speed * (bestAxis(horizontal, vertical)));
        }
    }

    /**
     * Choisit l'axe vertical ou horizontal pour ne pas faire de diagonale.
     */
    Vector3 bestAxis(Vector3 horizontal, Vector3 vertical)
    {
        // déplacement horizontal par défaut
        Vector3 meilleurAxe = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // choix d'un des deux axes possibles
        if (horizontal.magnitude > vertical.magnitude)
        {
            // bloquer l'axe z
            meilleurAxe.z = 0;
        }
        else if (horizontal.magnitude < vertical.magnitude)
        {
            // bloquer l'axe x
            meilleurAxe.x = 0;
        } else
        {
            // bloquer l'axe z
            meilleurAxe.z = 0;
        }
        return meilleurAxe;

    }
}

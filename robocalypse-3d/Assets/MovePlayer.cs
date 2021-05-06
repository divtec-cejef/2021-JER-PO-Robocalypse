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
            // Se déplacer uniquement sur l'axe vertical ou horizontal
            if (horizontal.magnitude > vertical.magnitude)
            {
                controller.Move(Time.deltaTime * speed * horizontal);
            }
            else if (vertical.magnitude > horizontal.magnitude)
            {
                controller.Move(Time.deltaTime * speed * vertical);
            }
            else if (vertical.magnitude == horizontal.magnitude)
            {
                controller.Move(Time.deltaTime * speed * horizontal);
            }

            // gameObject.transform.Translate(move);
            // controller.Move(  Time.deltaTime * speed * move);
        }
        
    }
}

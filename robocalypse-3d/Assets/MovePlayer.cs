using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        controller.Move(  Time.deltaTime * speed * move);
        
        if (move != Vector3.zero)
        {
            print("Bouton pressé");
            gameObject.transform.Translate(move);
        }
        
    }
}

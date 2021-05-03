using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller = new CharacterController();

    public float speed = 6f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 5)
            transform.position += Time.deltaTime * speed * Vector3.right;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -5)
            transform.position += Time.deltaTime * speed * Vector3.left;

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.z < 5)
            transform.position += Time.deltaTime * speed * Vector3.forward;

        if (Input.GetKeyDown(KeyCode.A) && transform.position.z > -1)
            transform.position += Time.deltaTime * speed * Vector3.back;
    }
}

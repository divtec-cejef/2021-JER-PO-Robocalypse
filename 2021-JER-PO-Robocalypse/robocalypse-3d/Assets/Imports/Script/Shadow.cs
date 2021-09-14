using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

    public Transform shadowTransform;
    public Transform objectTransform;

    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shadowTransform.position = new Vector3(objectTransform.position.x + x, y, objectTransform.position.z + z);
    }
}

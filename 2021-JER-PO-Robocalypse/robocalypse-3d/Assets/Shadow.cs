using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Transform transformShadow;
    public Transform transformObject;

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
        DeplacerOmbre(x, y, z);
    }

    private void LateUpdate()
    {

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }


    void DeplacerOmbre(float x, float y, float z)
    {

        transformShadow.position = new Vector3(transformObject.position.x + x, y, transformObject.position.z + z);
    }
}

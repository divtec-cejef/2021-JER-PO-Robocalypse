using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class projectilesBoss : MonoBehaviour
{

    private GameObject modeleCarotte;

    // Start is called before the first frame update
    void Start()
    {
        modeleCarotte = GameObject.Find("carrot");
        /*if (alimentAInstancier)
        {
            alimentAInstancier = GameObject.Find("Tomate");
            print("non");
        }*/
        // InvokeRepeating("ApparitionTomate", 1f, 7f);
        // InvokeRepeating("ApparitionCarotte", 2f, 7f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 

}

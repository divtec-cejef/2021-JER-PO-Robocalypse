using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuivreMrFreeze : MonoBehaviour
{
    private GameObject mrFreeze;

    private GameObject angryFace;

    private SpriteRenderer visageBossSprite;
    // Start is called before the first frame update
    void Start()
    {
        // trouver un os animé pour traquer le visage dessus
        mrFreeze = GameObject.Find("head");
        angryFace = GameObject.Find("visageBoss");
        visageBossSprite = angryFace.GetComponent<SpriteRenderer>();

        visageBossSprite.transform.Rotate(0, 0, 90F);

        StartCoroutine(changeFace());

    }

    // Update is called once per frame
    void Update()
    {
        // redimensionnement
        transform.localScale = new Vector3(0.7f, 0.7f, 1f); // z 1f

        // traquage de la position et rotation de Mr.Freeze
        transform.position = mrFreeze.transform.position + new Vector3(0, 1.3f, -0.3f/*3f, 1f, -2f*/); // -1.3f // MODIFIER VALEURS
        transform.localRotation = mrFreeze.transform.localRotation /** Quaternion.Euler(0f, 0f, -90f)*/;
        transform.rotation *= Quaternion.Euler(0f, 0f, -90f);



    }

    IEnumerator changeFace()
    {

        while (true)
        {
            if (Timer.timerIsRunning)
            {
                visageBossSprite.sprite = Resources.Load<Sprite>("Boss/visages/visage bleu");
            }

            yield return new WaitForSeconds(Random.Range(10, 20));

            if (Timer.timerIsRunning)
            {
                visageBossSprite.sprite = Resources.Load<Sprite>("Boss/visages/visage magenta");

            }

            yield return new WaitForSeconds(Random.Range(10, 20));

            print("vsage rose");

        }   
        
    }
}

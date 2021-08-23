using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modifierScore : MonoBehaviour
{

    private bool isTouched = false;

    public int nbrPointsParSphere = 1;

    private static int score;

    private Text txt_score;

    private GameObject floatingPoints;

    private Animator animator;

    private string nomProjectiles = "projectile";

    private int ancienRand;

    private ArrayList positionsPlusUn = new ArrayList()
    {
        new Vector3(-1.17f, 2.1f, 11.27f),
        new Vector3(0.27f, 3.6f, 11.27f),
        new Vector3(1.15f, 3.6f, 11.27f),
        new Vector3(0.09f, 1.78f, 11.27f),

    };

    // Start is called before the first frame update
    void Start()
    {
        txt_score = GameObject.Find("txt_Score").GetComponent<Text>();
        floatingPoints = GameObject.Find("+1");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.StartsWith("projectile"))
        {
            isTouched = true;
            
            int scoreActuel;
            bool a = int.TryParse(txt_score.text, out scoreActuel);
            score = scoreActuel + nbrPointsParSphere;

            // remplacement
            txt_score.text = score.ToString();

            
            if (isTouched  && scoreActuel % 5 == 0)
            {
                // faire un random
                Instantiate(floatingPoints, (Vector3)positionsPlusUn[1]/*transform.position + new Vector3(0, 3, -3)*/, Quaternion.identity);
                // revoir
                floatingPoints.GetComponent<Animator>().SetFloat("speed", 0.5f);
                // animator.SetTrigger("PlusUnFloating");

                isTouched = false;

            }




        }
    }
        
    private void inflate(GameObject objet)
    {

        

        // transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical") * 4 * Time.deltaTime);

    }
    private void destroyObject()
    {
        // Destroy(infoScore);

    }
}


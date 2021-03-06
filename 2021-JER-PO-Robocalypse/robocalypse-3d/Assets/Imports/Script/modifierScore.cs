using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class modifierScore : MonoBehaviour
{
    private ParticleSystem boss_particles;

    private bool isTouched = false;

    public int nbrPointsParSphere = 1;

    private static int score;

    private TextMeshProUGUI txt_score;

    //private GameObject floatingPoints;

    private Animator animator;

    private string nomProjectiles = "projectile";

    private int ancienRand;

    private GameObject expressionBoss;
    private GameObject projectile;



    // anciennes positions pour le plus un
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
        txt_score = GameObject.Find("txt_Score").GetComponent<TextMeshProUGUI>();
        //floatingPoints = GameObject.Find("+1");

        expressionBoss = GameObject.FindWithTag("expressionBoss");

        boss_particles = GameObject.Find("boss_particles").GetComponent<ParticleSystem>();

        boss_particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.StartsWith("projectile"))
        {

            string couleurProjectile = collision.collider.name;

            // traitement chaine caract
            couleurProjectile = couleurProjectile.Remove(0, 11); // retourne "bleu(Clone)"

            string exprBoss = expressionBoss.GetComponent<SpriteRenderer>().sprite.name;

            exprBoss = exprBoss.Remove(0, 7); // 7 // retourne "bleu"

            isTouched = true;

            int scoreActuel;
            bool a = int.TryParse(txt_score.text, out scoreActuel);

            if (couleurProjectile.Contains(exprBoss) || OnePlayerOption.onePlayer)
            {
                // on incr�mente le score uniquement si les projectiles sont de la m�me couleur que le visage du boss
                // ou si le joueur joue seul
                score = scoreActuel + nbrPointsParSphere;

                // remplacement
                txt_score.text = score.ToString();

                boss_particles.Play();
            }




            // if (isTouched  && scoreActuel % 5 == 0)
            //{
            // faire un random
            //   Instantiate(floatingPoints, (Vector3)positionsPlusUn[1]/*transform.position + new Vector3(0, 3, -3)*/, Quaternion.identity);
            // revoir
            //floatingPoints.GetComponent<Animator>().SetFloat("speed", 0.5f);
            // animator.SetTrigger("PlusUnFloating");

            // isTouched = false;

            // }




        }
    }

    private void destroyObject()
    {
        // Destroy(infoScore);

    }
}


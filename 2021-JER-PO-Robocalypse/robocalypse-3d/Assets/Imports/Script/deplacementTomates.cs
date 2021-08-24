using UnityEngine;

namespace Imports.Script
{
    public class deplacementTomates : MonoBehaviour{
        
        public float speed = 7f;

        private Vector3 initialPosition;
    
        WaitForSecondsRealtime waitForSecondsRealtime;

        private Rigidbody m_rigidbody;

        private bool hasTouchedTheGround;
       

        // Start is called before the first frame update
        void Start()
        {
            hasTouchedTheGround = false;
            initialPosition = transform.localScale;
            // m_rigidbody = transform.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            /*if (hasTouchedTheGround)
            {
                m_rigidbody.AddForce(Vector3.back * speed);

            }*/
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
            // canDelete = detectCollisionWithPlayer.Instance.Can
        


            // lévitation
            /*
        Vector3 posOffset = new Vector3 ();
        Vector3 tempPos = new Vector3 ();
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * 2f) * 0.5f; // fréquence, amplitude
*/
            // transform.position -= Vector3.MoveTowards(transform.position, (Vector3.forward + tempPos), 4 * Time.deltaTime);
            // transform.position -= (); /* = Vector3.MoveTowards(transform.position, new Vector3(0f,0f, 4f), 0.05f * Time.deltaTime);*/

            // transform.Translate( Time.deltaTime * speed * Vector3.forward);

        }
        void OnCollisionEnter(Collision collision)
        {
            hasTouchedTheGround = true;

            /*
             * if (collision.collider.name.StartsWith("Ground"))
            {
            
                float XScale = transform.localScale.x;
                float YScale = transform.localScale.y;
                float ZScale = transform.localScale.z;
 
                YScale = Mathf.MoveTowards(ZScale, 0.4f, 0.05f * Time.deltaTime);

                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 1.5f, transform.localScale.z); /*new Vector3(XScale, YScale, ZScale);*/
                // transform.localScale = new Vector3(YScale, 0.4f, 0.05f);


            //}
            
            if (collision.collider.name == "astronaute")
            {
                Destroy(gameObject);
                // décrémenter le score du joueur 
                // faire clignoter le joueur en rouge
            }
            if (collision.collider.name == "Invisiblewall (2)")
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            // transform.localScale = initialPosition;
        }

    }
}

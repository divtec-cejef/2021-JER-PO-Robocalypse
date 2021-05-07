using UnityEngine;

namespace Imports.Script
{
    public partial class MovePlayer : MonoBehaviour
    {

        public float jumph;
        public float jumpForce;
        
        private Vector3 jump;
        private Rigidbody rigg;
        private BoxCollider playerBoxCol;
        private Transform playerTransform;
        
        private bool isGrounded;

        // Start is called before the first frame update
        private void  Start()
        {
            jump = new Vector3(0f, jumph, 0f);
            rigg = GetComponent<Rigidbody>();
            playerBoxCol = GetComponent<BoxCollider>();
            playerTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (Input.GetKeyDown("o"))
            {
                playerBoxCol.size = new Vector3(1, 0.5f, 0.5f);
                playerTransform.localScale = new Vector3(1, 0.5f, 1);
            }

            if (Input.GetKeyUp("o"))
            {
                playerBoxCol.size = new Vector3(1, 1, 0.5f);
                playerTransform.localScale = new Vector3(1, 1, 1);
            }
            
            // jump
            if (rigg.velocity.y == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rigg.AddForce(jump * jumpForce, ForceMode.Impulse);
                }
            }
        }
    }
}

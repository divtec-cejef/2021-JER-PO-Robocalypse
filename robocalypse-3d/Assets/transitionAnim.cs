using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionAnim : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        
        Invoke(nameof(animer), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animer()
    {
        animator.enabled = true;
        animator.Play("transition_rond_end");
    }
}

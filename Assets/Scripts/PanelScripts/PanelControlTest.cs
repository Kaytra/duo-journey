using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControlTest : MonoBehaviour
{
    private Animator animator;
    private bool ispressed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !ispressed)
        {
            animator.SetBool("ispressed", true);
            ispressed = true;
        }

        else if (Input.GetKeyDown(KeyCode.E)&& ispressed)
        {
            animator.SetBool("ispressed", false);
            ispressed = false;
        }
    }

}

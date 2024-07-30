using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl1 : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool ispressed = false;

    public bool ishere = false;
    [SerializeField] private GameObject _promptText;
    public AudioSource buttonPress;
    // Start is called before the first frame update

     void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        
    
    
        
        if (other.CompareTag ("Player"))
        {
            ishere = true;
            _promptText.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            ishere = false;
            _promptText.SetActive(false);
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && ispressed == false & ishere == true) 
        {
            togglePanelOn();
            /*      Commented out by Kat to allow for access by Debug
            animator.SetBool("ispressed", true);
            ispressed = true;
            buttonPress.Play();
            */
        }

        else if (Input.GetKeyDown(KeyCode.E) && ispressed == true & ishere == true)
        {
            togglePanelOff();
            /*      Commented out by Kat to allow for access by Debug
            animator.SetBool("ispressed", false);
            ispressed = false;
            buttonPress.Play();
            */
        }
    }


    // added by Kat so script can be accessed by Debug properly
    public void togglePanelOn()
    {
        animator.SetBool("ispressed", true);
        ispressed = true;
        buttonPress.Play();
    }

    public void togglePanelOff()
    {
        animator.SetBool("ispressed", false);
        ispressed = false;
        buttonPress.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePanelPFI : MonoBehaviour
{
    public bool ispressed = false;

    private bool ishere = false;
    [SerializeField] private GameObject _promptText;
    public AudioSource bounce;
    public ParticleSystem BounceSpark;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player"))
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

        if (Input.GetKeyDown(KeyCode.Space) && ispressed == false & ishere == true)
        {
            togglePanelOn();
           
        }

        else if (Input.GetKeyDown(KeyCode.Space) && ispressed == true & ishere == true)
        {
            togglePanelOff();
           
        }
    }


    
    public void togglePanelOn()
    {
       
        ispressed = true;
        bounce.Play();
        BounceSpark.Play();
    }

    public void togglePanelOff()
    {
       
        ispressed = false;
        bounce.Play();
    }
}

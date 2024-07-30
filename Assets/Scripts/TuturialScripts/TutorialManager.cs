using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorText;
    private GameObject player;
    public bool finished;

    void Start()
    {
        finished = false;
        //tutorText.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ActivateTutor();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(finished == true)
    //    {
    //        if (other.tag == "Player")
    //        {
    //            DeactivateTutor();
    //        }
    //    }
    //}

    public void ActivateTutor()
    {
        tutorText.SetActive(true);       
    }

    public void DeactivateTutor()
    {
        tutorText.SetActive(false);
    }

    public void FinishTuroial()
    {
        finished = true;
    }
}

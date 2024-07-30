using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableT : MonoBehaviour
{
    public GameObject DoorTxt, collectTxt, tutorialPanel, tutorialManager, collectableManager, door;
    public bool collected, opened, complete;
    // Start is called before the first frame update
    void Start()
    {
        DoorTxt.SetActive(false);
        collected = false;
        opened = false;
        complete = false;
        collectableManager = GameObject.FindGameObjectWithTag("CollectableManager");
        door = GameObject.FindGameObjectWithTag("Hinge");

    }

    // Update is called once per frame
    void Update()
    {
        if(collectableManager.GetComponent<CollectableManager>().score >= 3)
        {
            collected = true;
        }

        if (collected == true && opened == false)
        {
            collectTxt.SetActive(false);
            DoorTxt.SetActive(true);
        }

        if(door.GetComponent<OpenDoor>().doorOpened == true)
        {
            opened = true;
            tutorialPanel.SetActive(false);
        }

        if ((collected == true && opened == true))
        {
            complete = true;
        }


    }

    private void Completed()
    {

        tutorialManager.GetComponent<TutorialManager>().finished = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (complete == true)
            {
                Completed();
            }
        }
    }
}

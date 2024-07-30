using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointT : MonoBehaviour
{
    public GameObject checkTxt, recallTxt, tutorialPanel, checkpointScript, tutorialManager;
    public bool linked, recalled, completed;

    // Start is called before the first frame update
    void Start()
    {
        recallTxt.SetActive(false);
        linked = false;
        recalled = false;
        completed = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkpointScript.GetComponent<CheckpointScript>().checkpnt == true)
        {
            checkTxt.SetActive(false);
            recallTxt.SetActive(true);
            linked = true;
        }

        if(linked == true && checkpointScript.GetComponent<CheckpointScript>().recall == true)
        {
            tutorialPanel.SetActive(false);
            recalled = true;
        }

        if (completed == true)
        {
            tutorialManager.GetComponent<TutorialManager>().finished = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (recalled == true && linked == true)
            {
                completed = true;
            }
        }
    }
}

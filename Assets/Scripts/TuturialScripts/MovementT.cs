using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementT : MonoBehaviour
{
    public GameObject moveTxt, jumpTxt, wallJumpTxt, tutorialPanel, tutorialManager;
    public bool movedR, movedL, jumped, complete;

    // Start is called before the first frame update
    void Start()
    {
        jumpTxt.SetActive(false);
        wallJumpTxt.SetActive(false);
        movedR = false;
        movedL = false;
        jumped = false;
        complete = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(movedR == false)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                movedR = true;
            }
        }

        if (movedL == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                movedL = true;
            }
        }


        if (movedL == true && movedR == true && jumped == false)
        {
            Moved();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpTxt.SetActive(false);
                wallJumpTxt.SetActive(true);
                jumped = true;
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(jumped == true)
            {
                Completed();
            }
        }
    }

    private void Moved()
    {

        moveTxt.SetActive(false);
        jumpTxt.SetActive(true);
    }

    private void Jumped()
    {
        Destroy(jumpTxt);
    }

    private void Completed()
    {
        complete = true;
        tutorialPanel.SetActive(false);
        tutorialManager.GetComponent<TutorialManager>().finished = true;
    }
}

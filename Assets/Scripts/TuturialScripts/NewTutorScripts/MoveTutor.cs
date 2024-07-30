using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutor : MonoBehaviour
{
    public GameObject MovementText, tutorialPanel, JumpPanel, wallJumpPanel;
    public TutorialManager tutorialManager;
    private bool moveR, moveL, jumpsActive, jumped;

    // Start is called before the first frame update
    void Start()
    {
        MovementText.SetActive(true);
        JumpPanel.SetActive(false);
        wallJumpPanel.SetActive(false);
        moveR = false;
        moveL = false;
        jumpsActive = false;
        jumped = false;
    }

    private void Update()
    {
        if (moveR == false)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                moveR = true;
            }
        }

        if (moveL == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                moveL = true;
            }
        }

        if (moveR == true && moveL == true)
        {
            MovementText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(moveR == true && moveL == true && jumpsActive == false)
        {
            JumpPanel.SetActive(true);
            jumpsActive = true;
        }

        if(jumpsActive == true && jumped == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpPanel.SetActive(false);
                wallJumpPanel.SetActive(true);
                jumped = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (jumped == true)
            {
                wallJumpPanel.SetActive(false);
                tutorialPanel.SetActive(false);
                tutorialManager.finished = true;
            }
        }
    }
}

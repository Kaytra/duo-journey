using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStatus : MonoBehaviour
{

    public bool S1_On, S2_On, S3_On, S4_On, S5_On;
    public bool puzzleComplete;
    public GameObject completeSound;
    public GameObject clue1_on, clue2_on, clue3_on, clue4_on, clue5_on, allClues;
    public GameObject clue1_off, clue2_off, clue3_off, clue4_off, clue5_off, clueFlash;
    private GameObject PuzzleCam;
    [SerializeField] GameObject mainCam = null;
    ///public GameObject switch01, switch02, switch03, switch04, switch05;

    void Start()
    {
        puzzleComplete = false;
        completeSound.SetActive(false);
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        PuzzleCam = GameObject.FindGameObjectWithTag("PuzzleCamera");
        PuzzleCam.SetActive(false);
        clueFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(S1_On == true && S2_On == true && S3_On == true && S4_On == true && S5_On == true)
        {
            puzzleComplete = true;
            clueFlash.SetActive(true);
            allClues.SetActive(false);
        }

        if(S1_On == true)
        {
            clue1_on.SetActive(true);
            clue1_off.SetActive(false);
        }
        else
        {
            clue1_on.SetActive(false);
            clue1_off.SetActive(true);
        }

        if (S2_On == true)
        {
            clue2_on.SetActive(true);
            clue2_off.SetActive(false);
        }
        else
        {
            clue2_on.SetActive(false);
            clue2_off.SetActive(true);
        }

        if (S3_On == true)
        {
            clue3_on.SetActive(true);
            clue3_off.SetActive(false);
        }
        else
        {
            clue3_on.SetActive(false);
            clue3_off.SetActive(true);
        }

        if (S4_On == true)
        {
            clue4_on.SetActive(true);
            clue4_off.SetActive(false);
        }
        else
        {
            clue4_on.SetActive(false);
            clue4_off.SetActive(true);
        }

        if (S5_On == true)
        {
            clue5_on.SetActive(true);
            clue5_off.SetActive(false);
        }
        else
        {
            clue5_on.SetActive(false);
            clue5_off.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        if(puzzleComplete == true)
        {
            completeSound.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PuzzleCam.SetActive(true);
            mainCam.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCam.SetActive(true);
            PuzzleCam.SetActive(false);            
        }
    }

    public void ActivateSwitch01()
    {
        SwitchSound();
        S1_On = !S1_On;
        S2_On = !S2_On;
    }

    public void ActivateSwitch02()
    {
        SwitchSound();
        S2_On = !S2_On;
        S1_On = !S1_On;
        S3_On = !S3_On;
    }

    public void ActivateSwitch03()
    {
        SwitchSound();
        S3_On = !S3_On;
        S2_On = !S2_On;
        S4_On = !S4_On;
    }

    public void ActivateSwitch04()
    {
        SwitchSound();
        S4_On = !S4_On;
        S3_On = !S3_On;
        S5_On = !S5_On;
    }

    public void ActivateSwitch05()
    {
        SwitchSound();
        S5_On = !S5_On;
        S4_On = !S4_On;
    }

    public void SwitchSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    public GameObject Rune1_On;
    public GameObject Rune2_On;
    public GameObject Rune1_Off;
    public GameObject Rune2_Off;
    public GameObject DoorActive;
    public GameObject DoorInactive;
    public GameObject tutorialStatus;

    // Start is called before the first frame update
    void Start()
    {
        Rune1_On.SetActive(false);
        Rune2_On.SetActive(false);
        DoorInactive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (tutorialStatus.GetComponent<TutorialManager>().finished == true)
        {
            Invoke("PuzzleCompleted", 1.01f);
        }

    }

    public void PuzzleCompleted()
    {
        Rune1_On.SetActive(true);
        Rune1_Off.SetActive(false);
        Invoke("Rune2Burn", .50f);
        Invoke("DoorBreak", 1.0f);


    }
    public void Rune2Burn()
    {
        Rune2_On.SetActive(true);
        Rune2_Off.SetActive(false);
    }
    
    public void DoorBreak()
    {
        DoorInactive.SetActive(true);
        Invoke("RemoveBarrier", .35f);
    }
    public void RemoveBarrier()
    {
        DoorActive.SetActive(false);
    }
}

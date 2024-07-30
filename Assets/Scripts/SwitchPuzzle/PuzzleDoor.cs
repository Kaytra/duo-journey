using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    public GameObject Rune1_On;
    public GameObject Rune2_On;
    public GameObject Rune3_On;
    public GameObject Rune4_On;
    public GameObject Rune1_Off;
    public GameObject Rune2_Off;
    public GameObject Rune3_Off;
    public GameObject Rune4_Off;
    public GameObject DoorActive;
    public GameObject DoorInactive;
    public GameObject puzzleStatusObj;

    // Start is called before the first frame update
    void Start()
    {
        Rune1_On.SetActive(false);
        Rune2_On.SetActive(false);
        Rune3_On.SetActive(false);
        Rune4_On.SetActive(false);
        DoorInactive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    PuzzleCompleted();
        //}
    }

    void FixedUpdate()
    {
        if (puzzleStatusObj.GetComponent<SwitchStatus>().puzzleComplete == true)
        {
            Invoke("PuzzleCompleted", 1.01f);
        }

    }

    public void PuzzleCompleted()
    {
        Rune1_On.SetActive(true);
        Rune1_Off.SetActive(false);
        Invoke("Rune2Burn", .50f);
        Invoke("Rune3Burn", 1.0f);
        Invoke("Rune4Burn", 1.5f);
        Invoke("DoorBreak", 2.0f);
    }
    public void Rune2Burn()
    {
        Rune2_On.SetActive(true);
        Rune2_Off.SetActive(false);
    }
    public void Rune3Burn()
    {
        Rune3_On.SetActive(true);
        Rune3_Off.SetActive(false);
    }
    public void Rune4Burn()
    {
        Rune4_On.SetActive(true);
        Rune4_Off.SetActive(false);
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

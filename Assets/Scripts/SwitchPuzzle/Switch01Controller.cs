using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch01Controller : MonoBehaviour
{
    public GameObject puzzleStatusObj;
    public GameObject onLight;
    public GameObject offLight;
    private GameObject player;
    public bool switchable;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        switchable = false;
    }

    void Update()
    {
        if(puzzleStatusObj.GetComponent<SwitchStatus>().S1_On == true)
        {
            onLight.SetActive(true);
            offLight.SetActive(false);
        }
        else
        {
            onLight.SetActive(false);
            offLight.SetActive(true);
        }

        if (switchable == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                puzzleStatusObj.GetComponent<SwitchStatus>().ActivateSwitch01();
            }
        }
    }
}

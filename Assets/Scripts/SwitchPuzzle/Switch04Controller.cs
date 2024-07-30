using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch04Controller : MonoBehaviour
{
    public GameObject puzzleStatusObj;
    public GameObject onLight;
    public GameObject offLight;
    private GameObject player;
    public bool switchable;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        switchable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleStatusObj.GetComponent<SwitchStatus>().S4_On == true)
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
                puzzleStatusObj.GetComponent<SwitchStatus>().ActivateSwitch04();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuzzleDectector : MonoBehaviour
{
    private GameObject switch01;
    private GameObject switch02;
    private GameObject switch03;
    private GameObject switch04;
    private GameObject switch05;
    public GameObject puzzleStatusObj;
    public GameObject switchTxt;

    void Start()
    {
        switch01 = GameObject.FindGameObjectWithTag("Switch1");
        switch02 = GameObject.FindGameObjectWithTag("Switch2");
        switch03 = GameObject.FindGameObjectWithTag("Switch3");
        switch04 = GameObject.FindGameObjectWithTag("Switch4");
        switch05 = GameObject.FindGameObjectWithTag("Switch5");
        switchTxt.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(puzzleStatusObj.GetComponent<SwitchStatus>().puzzleComplete == false)
        {
            if (other.tag == "Switch1")
            {
                switch01.GetComponent<Switch01Controller>().switchable = true;
                switchTxt.SetActive(true);
            }
            if (other.tag == "Switch2")
            {
                switch02.GetComponent<Switch02Controller>().switchable = true;
                switchTxt.SetActive(true);
            }
            if (other.tag == "Switch3")
            {
                switch03.GetComponent<Switch03Controller>().switchable = true;
                switchTxt.SetActive(true);
            }
            if (other.tag == "Switch4")
            {
                switch04.GetComponent<Switch04Controller>().switchable = true;
                switchTxt.SetActive(true);
            }
            if (other.tag == "Switch5")
            {
                switch05.GetComponent<Switch05Controller>().switchable = true;
                switchTxt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Switch1")
        {
            switch01.GetComponent<Switch01Controller>().switchable = false;
            switchTxt.SetActive(false);
        }
        if (other.tag == "Switch2")
        {
            switch02.GetComponent<Switch02Controller>().switchable = false;
            switchTxt.SetActive(false);
        }
        if (other.tag == "Switch3")
        {
            switch03.GetComponent<Switch03Controller>().switchable = false;
            switchTxt.SetActive(false);
        }
        if (other.tag == "Switch4")
        {
            switch04.GetComponent<Switch04Controller>().switchable = false;
            switchTxt.SetActive(false);
        }
        if (other.tag == "Switch5")
        {
            switch05.GetComponent<Switch05Controller>().switchable = false;
            switchTxt.SetActive(false);
        }
    }
}

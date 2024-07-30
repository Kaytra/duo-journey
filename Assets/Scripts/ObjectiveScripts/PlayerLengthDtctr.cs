using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLengthDtctr : MonoBehaviour
{
    public GameObject lengthObj;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mk1")
        {
            lengthObj.GetComponent<LengthObjective>().mk1 = true;
        }
        if (other.tag == "mk2")
        {
            lengthObj.GetComponent<LengthObjective>().mk2 = true;
        }
        if (other.tag == "mk3")
        {
            lengthObj.GetComponent<LengthObjective>().mk3 = true;
        }
        if (other.tag == "mk4")
        {
            lengthObj.GetComponent<LengthObjective>().mk4 = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LengthObjective : MonoBehaviour
{
    public bool mk1, mk2, mk3, mk4;
    public GameObject mk25, mk50, mk75, mk100;
    public GameObject objCompleted;
    // Start is called before the first frame update
    void Start()
    {
        objCompleted.SetActive(false);
        mk1 = false;
        mk2 = false;
        mk3 = false;
        mk4 = false;
        mk25.SetActive(false);
        mk50.SetActive(false);
        mk75.SetActive(false);
        mk100.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mk1 == true)
        {
            mk25.SetActive(true);
        }
        if (mk2 == true)
        {
            mk50.SetActive(true);
        }
        if (mk3 == true)
        {
            mk75.SetActive(true);
        }
        if (mk4 == true)
        {
            mk100.SetActive(true);
        }
    }
}

    

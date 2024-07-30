using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjective : MonoBehaviour
{
    public GameObject puzzleStatusObj;
    public GameObject objCompleted;
    // Start is called before the first frame update
    void Start()
    {
        objCompleted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleStatusObj.GetComponent<SwitchStatus>().puzzleComplete == true)
        {
            objCompleted.SetActive(true);
        }
    }
}

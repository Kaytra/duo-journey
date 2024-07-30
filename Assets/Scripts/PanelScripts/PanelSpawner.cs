using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpawner : MonoBehaviour
{
    public GameObject Panel; 
    

    // Update is called once per frame
    void Update()
    {
        if (Panel.activeSelf == false)
        {
            Invoke("Respawn", 3.0f);
        }


    }
        void Respawn()
        {
            Panel.SetActive(true);
        }
}

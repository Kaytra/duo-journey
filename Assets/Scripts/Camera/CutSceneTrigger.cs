using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    // we need to reference to our Cutscene System
    public CutScene cutSys;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        cutSys.thePlayer = player.transform;
        //Locater the players Camera and save it
        //cutSys.playerCam = GameObject.FindWithTag("MainCamera");
        //Save the Players position in the Cutscene System
        cutSys.lastPos = player.transform.position;
        //Enable the Cutscenes Camera
        cutSys.cutCam.SetActive(true);
        // Start the Cutscene
        cutSys.StartCutscene();
        //This shouldnt trigger again. kill the trigger object
        Destroy(gameObject);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    // an object with collision has enetered. Is it tagged as player?
    //    if (other.tag == "Player")
    //    {
    //        //It is the player, tell the Cutscene System
    //        cutSys.thePlayer = other.transform;
    //        //Locater the players Camera and save it
    //        cutSys.playerCam = GameObject.FindWithTag("MainCamera");
    //        //Save the Players position in the Cutscene System
    //        cutSys.lastPos = other.transform.position;
    //        //Enable the Cutscenes Camera
    //        cutSys.cutCam.SetActive(true);
    //        // Start the Cutscene
    //        cutSys.StartCutscene();
    //        //This shouldnt trigger again. kill the trigger object
    //        Destroy(gameObject);
    //    }
    //}
}

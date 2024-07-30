using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    

    //Nickname for the players Camera
    public GameObject playerCam;
    //Nickname for the Cutscenes Camera
    public GameObject cutCam;
    //Nickname fo rthe Cutscenes Animator
    [SerializeField] private Animator cutAnim;
    // Toggle for looking the players movement
    private bool lockPlayer = false;
    //Nickname for the players Transform
    public Transform thePlayer;
    //Nickname for the last saved position
    public Vector3 lastPos;
    public string AnimTrigger;
    //UI stuffs to allow for skipping
    public GameObject CutSceneUI;

    public GameObject PlayerBody;
    //Start is called before the first frame update
    private void Start()

    {
        
        // MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //Give our Animato a nickname
        cutAnim = GetComponent<Animator>();
        //Disable the Cutscenes Camera till triggered
        //cutCam.SetActive(false);

        //UI disabled
        //CutSceneUI.SetActive(false);
        //StartCutscene();
    }

    //Update is called once pre frame
    private void Update()
    {
        // Locking the Players position during the cutscene
        if (lockPlayer == true)
        {
            // if we know where the player id
            if (thePlayer != null)
            {
                // set the player where they were until we say otherwise
                thePlayer.position = lastPos;
            }
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCutscene();
        }
    }*/

    public void StartCutscene()
    {
        // Disable the players Camera
        playerCam.SetActive(false);
        // MainCamera.enabled = false;
        //Hold the players possition
        lockPlayer = true; 
        // Trigger thr Cutscene animation!
        cutAnim.SetTrigger(AnimTrigger);

        PlayerBody.GetComponent<CharacterMovement>().enabled = false;
        CutSceneUI.SetActive(true);
        Cursor.visible = true;
    }

    public void StopCutscene()
    {
        // enable the players Camera
        playerCam.SetActive(true);
        //MainCamera.enabled = true;
        //Disable the Cutscenes Camera
        cutCam.SetActive(false);
        //Allow the Player to move again
        lockPlayer = false; 

        PlayerBody.GetComponent<CharacterMovement>().enabled = true;
        CutSceneUI.SetActive(false);
        Cursor.visible = false;

    }
}

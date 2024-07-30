using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{
    public float maxSpirit;
    public float curSpirit;
    public float TickTime;
    public float holdTime;
    public float holdCount;
    public GameObject player;
    public GameObject spawn;
    public GameObject cantLink;
    [SerializeField] ParticleSystem vanish;
    public GameObject vanishObj;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        maxSpirit = spawn.GetComponent<CheckpointScript>().maxSpirit;
        curSpirit = spawn.GetComponent<CheckpointScript>().curSpirit;
        if (curSpirit >= 50)
        {
            if (Input.GetKey(KeyCode.X) && holdCount < 0.5f)
            {
                holdTime -= Time.deltaTime;
                if (holdTime <= 0)
                {
                    holdCount += 0.01f;
                    holdTime = 0.01f;
                }
            }
            if (Input.GetKey(KeyCode.X) && holdCount >= 0.5f)
            {
                vanishObj.transform.position = player.transform.position;
                vanish.Play();
                vanishObj.GetComponent<AudioSource>().Play();
                player.SetActive(false);
                Invoke("ResetLocation", 0.01f);
                Invoke("ReactivatePlayer", 0.02f);
                holdCount = 0;
                spawn.GetComponent<CheckpointScript>().curSpirit -= 50;
            }
            if (Input.GetKeyUp(KeyCode.X) && holdCount < 0.5f)
            {
                holdCount = 0;
            }

            if (curSpirit < 50)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    cantLink.SetActive(true);
                    Invoke("CantLinkOff", 1.5f);
                }
            }
        }
        //if (Input.GetKey(KeyCode.P))
        //{
        //    player.SetActive(false);
        //    Invoke("ResetLocation", 0.01f);
        //    Invoke("ReactivatePlayer", 0.02f);
        //}
    }

    public void ResetLocation()
    {
        spawn.GetComponent<CheckpointScript>().teleportPlayerToCheckpoint();
        //player.GetComponent<Transform>().rotation = spawn.GetComponent<Transform>().rotation;
    }

    public void ReactivatePlayer()
    {
        player.SetActive(true);
    }

    public void CantLinkOff()
    {
        cantLink.SetActive(false);
    }
}

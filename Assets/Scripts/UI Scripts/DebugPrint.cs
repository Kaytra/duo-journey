using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPrint : MonoBehaviour
{

    [SerializeField] private AudioSource hoverSFX;
    [SerializeField] private AudioSource clickSFX;
    [SerializeField] private AudioSource errorSFX;
    private GameObject player;
    private bool invincibility;
    private float playerDPS;
    private float playerVel;

    public Text invincibilityStatus;
    public Text dps;
    public Text vel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        clickSFX = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            invincibility = player.GetComponent<PlayerHealth>().isInvulnerable;
            //playerVel = player.GetComponent<Rigidbody>().velocity.x;
            vel.text = playerVel.ToString("2F");

            if(invincibility == true)
                invincibilityStatus.text = "ON";
            else
                invincibilityStatus.text = "OFF";
        }
    }

    public void ClickSound()
    {
        clickSFX.Play();
    }

    public void HoverSound()
    {
        hoverSFX.Play();
    }

    public void ErrorSound()
    {
        errorSFX.Play();
    }
}

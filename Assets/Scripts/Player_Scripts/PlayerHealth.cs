using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("UI")]
    public int health;
    public int maxHealth = 4;
    public GameObject HealthOrb_01_On;
    public GameObject HealthOrb_02_On;
    public GameObject HealthOrb_03_On;
    public GameObject HealthOrb_04_On;
    //[SerializeField] GameObject _deathUI = null;

    [Header("Particle System")]
    [SerializeField] ParticleSystem deathCloud;
    public GameObject cloud;
    public GameObject PlayerBody;
    public GameObject player;
    private AudioSource poof;

    private AudioSource hit;
    public GameObject hitSource;
    public GameObject spawn;

    public bool isInvulnerable = false;
    public CheckpointScript checkPointScript;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        hit = hitSource.GetComponent<AudioSource>();
        poof = cloud.GetComponent<AudioSource>();
        //if (_deathUI == null)
        //    Debug.LogError("Death UI is not assigned!");
        //else
        //    _deathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        
        if (health == 4)
        {
            HealthOrb_01_On.SetActive(true);
            HealthOrb_02_On.SetActive(true);
            HealthOrb_03_On.SetActive(true);
            HealthOrb_04_On.SetActive(true);
        }
        if (health == 3)
        {
            HealthOrb_04_On.SetActive(false);

            HealthOrb_01_On.SetActive(true);
            HealthOrb_02_On.SetActive(true);
            HealthOrb_03_On.SetActive(true);

        }
        if (health == 2)
        {
            HealthOrb_03_On.SetActive(false);
            HealthOrb_04_On.SetActive(false);


            HealthOrb_01_On.SetActive(true);
            HealthOrb_02_On.SetActive(true);
        }
        if (health == 1)
        {
            HealthOrb_02_On.SetActive(false);
            HealthOrb_03_On.SetActive(false);
            HealthOrb_04_On.SetActive(false);

            HealthOrb_01_On.SetActive(true);
        }
        if (health == 0)
        {
            HealthOrb_01_On.SetActive(false);
            HealthOrb_02_On.SetActive(false);
            HealthOrb_03_On.SetActive(false);
            HealthOrb_04_On.SetActive(false);
        }

        if (PlayerBody == null)
        {
            PlayerBody = player;
        }
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            Invoke("DeathAnim", 2.2f);
            //deathCloud.Play();
            //poof.Play();
            ////_deathUI.SetActive(true);
            //PlayerBody.SetActive(false);
            //Invoke("StopCloud", 2.1f);
            //checkPointScript.Invoke("Respawn", 2.2f);
            ////Invoke("PlayerRespawn", 2.3f);
            ////Invoke("Death_UI", 2.15f);
        }
    }

    public void HurtPlayer()
    {
        if (isInvulnerable == false)
        {
            health -= 1;
            if (health > 0)
            {
                ScreenShake.instance.StartShake(.2f, .1f);
                hit.Play();
            }
        }
    }

    public void HealPlayer_1()
    {
        health += 1;
    }

    void StopCloud()
    {
        cloud.SetActive(false);
    } 
     void ResetCloud()
    {
        cloud.SetActive(true);
    }
    //void Death_UI()
    //{
    //    _deathUI.SetActive(true);
    //}

    public void PlayerRespawn()
    {
        health = 4;
    }

    public void invinciblity()
    {
        isInvulnerable = !isInvulnerable;
    }

    public void DeathAnim()
    {
        poof.Play();
        deathCloud.Play();

        PlayerBody.SetActive(false);
        Invoke("StopCloud", 3.1f);
        checkPointScript.Invoke("Respawn", 3.2f);
        Invoke("ResetCoud", 3.3f);

    }
}

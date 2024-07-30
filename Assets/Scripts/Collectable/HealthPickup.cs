using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    //PlayerHealth playerHealth;

    //public float healthBonus = 15f;

   // [Header("UI")]
    public int health;
    public int maxHealth = 4;

    private GameObject player;

    //PlayerHealth playerhealth;
    public AudioSource pickUp;
    public ParticleSystem Particlel;


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            pickUp.Play();
            Particlel.Play();
            player.gameObject.GetComponent<PlayerHealth>().HealPlayer_1();
            Destroy(gameObject, 0.4f);
            //gameObject.SetActive(false);
        }


        //{
        //    playerhealth = col.gameObject.AddComponent<PlayerHealth>() as PlayerHealth;
        //}
        

    
        //{
        //    playerhealth = col.gameObject.GetComponent<PlayerHealth>();
        //}

    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {

            Particlel.Play();
        }
        // Start is called before the first frame update
    }
        void Start()
        {
            //Particlel = gameObject.GetComponent<ParticleSystem>();
             pickUp = gameObject.GetComponent<AudioSource>();
            player = GameObject.FindGameObjectWithTag("Player");
            //playerhealth.HealPlayer_1();
            //player = GameObject.FindGameObjectWithTag("Player");



        }

        // Update is called once per frame


        //private void Awake()
        //{
        //playerHealth = FindObjectOfType<PlayerHealth>();
        // }

        //private void OnTriggerEnter2D(Collider2D col)
        //{
        // if (playerHealth.health < playerHealth.maxHealth)
        //{
        //Destroy(gameObject);
        //playerHealth.health = playerHealth.health + healthBonus;
        //}

    
    //}
}


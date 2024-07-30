using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReactivate : MonoBehaviour
{
    public GameObject self;
    private GameObject player;
    public int health;
    public int playerHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player.GetComponent<PlayerHealth>().health == 0)
        {
            Invoke("Activate", 2.2f);
        }
    }
    public void Activate()
    {
        self.SetActive(true);
    }
}

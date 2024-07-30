using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRespawn : MonoBehaviour
{
    public GameObject Collectable;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        if (player.GetComponent<PlayerHealth>().health == 0)
        {
            Invoke("Respawn", 2.2f);
        }
    }

    public void Respawn()
    {
        Collectable.SetActive(true);
    }
}



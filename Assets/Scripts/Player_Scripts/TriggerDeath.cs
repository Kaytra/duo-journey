using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    public GameObject playerBody;


    private void OnTriggerEnter(Collider other)
    {
        playerBody.GetComponent<PlayerHealth>().health = 0;
        Destroy(this);
    }
}

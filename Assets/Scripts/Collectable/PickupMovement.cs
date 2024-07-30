using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    public float speed;
    public float range;
    private Vector3 playerLoc;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerLoc = new Vector3(player.transform.position.x, player.transform.position.y);
        float currentDistance;
        currentDistance = Vector3.Distance(transform.position, player.transform.position);
        if (currentDistance < range)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerLoc, speed * Time.deltaTime);
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, playerLoc, speed * Time.deltaTime);
    //    }
    //}
}

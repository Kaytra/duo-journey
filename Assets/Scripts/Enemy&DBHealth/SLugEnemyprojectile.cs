using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLugEnemyprojectile : MonoBehaviour
{
    public float speed;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        //target = new Vector3(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().HurtPlayer();
            DestroyProjectile();
        }
        else
        {
            if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wall")
            {
                DestroyProjectile();
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HurtPlayer();
            DestroyProjectile();
        }
        else
        {
            DestroyProjectile();
        }
    }*/


    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
        
}

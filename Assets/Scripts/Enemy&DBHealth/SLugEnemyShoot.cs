using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLugEnemyShoot : MonoBehaviour
{
    private float timeBtwshots;
    public float startTimeBtwShots;

    public GameObject projectile;

    public bool attacking = false;

     void Start()
     {
        timeBtwshots = startTimeBtwShots;
     }

    void Update()
    {
        if (attacking == true)
        {
            if (timeBtwshots <= 0)
            {
                Instantiate(projectile, transform.position, gameObject.transform.rotation);
                timeBtwshots = startTimeBtwShots;
            }
            else
            {
                timeBtwshots -= Time.deltaTime;
            }
        }
        else
        {
            timeBtwshots = startTimeBtwShots;
        }
    }

     void OnCollisionExit(Collision collision)
    {
        timeBtwshots = 0;
    }
}

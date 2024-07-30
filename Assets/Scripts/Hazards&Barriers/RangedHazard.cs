using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedHazard : MonoBehaviour
{
    [SerializeField] GameObject projectile = null;
    [SerializeField] GameObject firingSpot = null;
    [SerializeField] float fireRate = 5;
    private AudioSource mySource;
    private float timer = 0;
    private bool canFire = true;

    private void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= fireRate && canFire == true)
        {
            //Debug.Log(gameObject.name + " has fired");
            mySource.Play();
            Instantiate(projectile, firingSpot.transform.position, GetComponentInParent<Transform>().rotation);
            timer = 0;
        }
    }

    public void toggleFireing()
    {
        canFire = !canFire;
    }
}

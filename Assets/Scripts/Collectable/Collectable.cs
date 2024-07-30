using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int collectableValue = 1;
    ParticleSystem collectParticle;
   public AudioSource collected;

    void Start()
    {
        collectParticle = GetComponent<ParticleSystem>();

        //collected = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            collectParticle.Play();
           
            collected.Play();
            CollectableManager.instance.ChangeScore(collectableValue);
            //Destroy(this.gameObject, 0.4f);
            Invoke("SetInactive", 0.4f);
        }

      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectParticle.Play();
        }
    }
    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    void SetInactive()
    {
        gameObject.SetActive(false);
    }

    
}

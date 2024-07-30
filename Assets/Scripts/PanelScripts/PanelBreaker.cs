using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.WSA.Input;

public class PanelBreaker : MonoBehaviour
{
    float BreakTime;
    public GameObject panel;
    public AudioSource woodsound;
    public AudioSource breakingsound;
    public GameObject Rockhit;

    public bool Iswalking = false;
    // Start is called before the first frame update
    
    
    IEnumerator BreakingTime(float countdownTime = 5)
    {
        BreakTime = countdownTime;
        while (BreakTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Breaking in " + BreakTime);
            BreakTime--;

        }

        if(Iswalking == false)
        {
            StopCoroutine(BreakingTime());
        }

        if(BreakTime < 1)
        {
            breakingsound.Play();
            panel.SetActive(false);
            Rockhit.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            StartCoroutine(BreakingTime());
            woodsound.Play();
            Iswalking = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            StopAllCoroutines();
            woodsound.Stop();
            Iswalking = false;
        }
    }

}

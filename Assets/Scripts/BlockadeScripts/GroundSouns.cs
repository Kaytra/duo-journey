using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSouns : MonoBehaviour
{
    public AudioSource Sliding;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            Sliding.Play();
        }
    }
}

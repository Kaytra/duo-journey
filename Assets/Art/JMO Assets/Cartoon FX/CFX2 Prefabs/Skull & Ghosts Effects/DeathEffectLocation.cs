using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffectLocation : MonoBehaviour
{
    public GameObject particleSpawnPoint;
    private Transform currentPosiiton;

    // Start is called before the first frame update
    void Start()
    {
        currentPosiiton = gameObject.GetComponent<Transform>();
        gameObject.transform.position = particleSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (particleSpawnPoint != null)
        {
            gameObject.transform.position = particleSpawnPoint.transform.position;
        }
        if (particleSpawnPoint == null)
        {
            gameObject.transform.position = currentPosiiton.transform.position;
        }
    }
}

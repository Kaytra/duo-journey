using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckpoint : MonoBehaviour
{
    private GameObject playerParentRef = null;
    [SerializeField] private BossAI _aIRef = null;

    private void Start()
    {
        if (_aIRef == null)
            _aIRef.GetComponentInParent<BossAI>();
    }

    private void FixedUpdate()
    {
        if (_aIRef.checkBossFightActive() == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerParentRef = other.gameObject.transform.parent.gameObject;
            playerParentRef.GetComponentInChildren<CheckpointScript>().SpiritLink();        }
    }
}

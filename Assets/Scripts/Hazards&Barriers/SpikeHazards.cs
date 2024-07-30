using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHazards : MonoBehaviour
{
    /*[SerializeField] float KbStrength = 2;
    [SerializeField] GameObject _Player = null;
    [SerializeField] int damage = 1;
    [SerializeField] Transform mytrans = null;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == _Player)
        {
            _Player.GetComponent<PlayerHealth>().health -= damage;
            Vector2 direc = (_Player.GetComponentInParent<Transform>().position - mytrans.position).normalized;
            _Player.GetComponent<Rigidbody>().AddForce(direc * KbStrength, ForceMode.Impulse);
        }
    }*/
}

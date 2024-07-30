using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingVision : MonoBehaviour
{
    [SerializeField] HoppingEnemy _hoppingenemy = null;
    private AudioSource alertSFX;
    [SerializeField] private GameObject _playerBody = null;
    [SerializeField] private bool _playerDetected = false;
    private bool enemyAlerted = false;
    [SerializeField] private float _sightRange = 7f;

    private void Start()
    {
        alertSFX = GetComponent<AudioSource>();
        if (_playerBody == null)
            _playerBody = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, _playerBody.transform.position - transform.position, Color.red);
        if (Physics.Raycast(transform.position, _playerBody.transform.position - transform.position, out hit, _sightRange))
        {
            if (hit.collider.gameObject.tag == "Player" && !enemyAlerted)
            {
                enemyAlerted = true;
                alertSFX.Play();
                _hoppingenemy._isAttacking = true;
            }
        }
        else
        {
            enemyAlerted = false;
            _hoppingenemy._isAttacking = false;
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            alertSFX.Play();
            _hoppingenemy._isAttacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _hoppingenemy._isAttacking = false;
        }
    }
    */
}

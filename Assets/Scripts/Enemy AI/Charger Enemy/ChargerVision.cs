using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerVision : MonoBehaviour
{
    [SerializeField] Charger _charger = null;
    private AudioSource alertSFX;
    [SerializeField] private GameObject _playerBody = null;
    [SerializeField] private bool _playerDetected = false;
    private bool enemyAlerted = false;
    [SerializeField] private float _sightRange = 10f;

    void Start()
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
                _charger._isAttacking = true;
            }
        }
        else
        {
            enemyAlerted = false;
            _charger._isAttacking = false;
            //_charger.RB.velocity = new Vector3(0, 0, 0);
            //_charger.RB.rotation.Set(0, 0, 0, 0);
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _charger._player)
        {
            _mySource.Play();
            _charger._isAttacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _charger._player)
        {
            _charger._isAttacking = false;
            _charger.RB.velocity = new Vector3(0,0,0);
            _charger.RB.rotation.Set(0,0,0,0);
        }
    }
    */
}

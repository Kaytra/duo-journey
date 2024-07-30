using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugEnemySight : MonoBehaviour
{
    private AudioSource mysource;
    public GameObject Projectile;
    [SerializeField] SlugEnemyWaypoint _movementRef = null;
    [SerializeField] GameObject _playerBody = null;

    [SerializeField] float _sightRange = 7f;

    public bool activateme;
    private void Start()
    {
        Projectile.SetActive(false);
        mysource = GetComponent<AudioSource>();
        
        _movementRef = GetComponentInParent<SlugEnemyWaypoint>();
        _playerBody = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(_movementRef.gameObject.transform.position, _playerBody.transform.position - _movementRef.gameObject.transform.position, Color.red);
        if (Physics.Raycast(gameObject.transform.position, _playerBody.transform.position - transform.position, out hit, _sightRange))
        {
            if (hit.collider.tag == "Player")
            {
                _movementRef.stopMoving();
                mysource.Play();
                Projectile.SetActive(true);
                Projectile.GetComponent<SLugEnemyShoot>().attacking = true;
            }
        }
        else
        {
            _movementRef.resumeMoving();
            Projectile.GetComponent<SLugEnemyShoot>().attacking = false;
            Projectile.SetActive(false);
        }
    }
}

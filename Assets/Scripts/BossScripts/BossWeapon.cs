using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab = null;
    [SerializeField] private float _fireTime = 50f;
    private float timer = 0f;
    [SerializeField] private GameObject projectileRef;
    [SerializeField] private PlayerHealth _playerHealthRef;
    private GameObject playerBodyRef;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_projectilePrefab == null)
            Debug.LogError("Boss projectile is not assinged!");
        if (_playerHealthRef == null)
            _playerHealthRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerBodyRef = _playerHealthRef.gameObject;
    }

    public void fireBasicAttack()
    {
        //Debug.Log("Fireing Basic Attack from - " + this.gameObject.name);
        if (playerBodyRef.activeInHierarchy == true)
        {
            projectileRef = Instantiate(_projectilePrefab, this.transform);
            projectileRef = null;
        }
    }

    public void fireStrongAttack(int shotAmount, float timeBetweenShots)
    {
        //Debug.Log("Fireing Strong Attack from - " + this.gameObject.name);
        if (playerBodyRef.activeInHierarchy == true)
        {
            StartCoroutine(fireStrongCoroutine(shotAmount, timeBetweenShots));
        }
    }

    IEnumerator fireStrongCoroutine(int i, float f)
    {
        for (int j = 0; j < i; j++)
        {
            projectileRef = Instantiate(_projectilePrefab, this.transform);
            projectileRef = null;

            yield return new WaitForSeconds(f);
        }
    }

    public void resetWeapon()
    {
        timer = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakpoint : MonoBehaviour
{
    [SerializeField] private GameObject _bodyRef = null;
    //[SerializeField] private GameObject _connectionToBoss = null;

    [SerializeField] private bool _isAlive = true;
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth = 3;

    [SerializeField] private BossWeapon _selfWeaponRef = null;
    [SerializeField] private BossAI _aIRef = null;
    [SerializeField] private bool sfxPlayed = false;

    private Material ctb_Material;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _selfWeaponRef = this.gameObject.GetComponent<BossWeapon>();
        _aIRef = gameObject.GetComponentInParent<BossAI>();
        /*
        if (_connectionToBoss == null)
            Debug.LogError(this.gameObject.name + " - does not have Connection To Boss assigned!");
        else
            ctb_Material = _connectionToBoss.GetComponent<Renderer>().material;
        */
    }

    private void Update()
    {
        if (_isAlive)
        {
            //ctb_Material.color = Color.red;
        }
        if (!_isAlive)
        {
            _currentHealth = 0;
            //ctb_Material.color = Color.black;
        }
        if (_currentHealth == 0)
        {
            _isAlive = false;
            if (sfxPlayed == false)
            {
                _aIRef.playBossGroan();
                sfxPlayed = true;
            }

            _bodyRef.SetActive(false);
            _selfWeaponRef.enabled = false;

        }
    }

    public void hideConnction()
    {
        //_connectionToBoss.SetActive(false);
    }

    public void spawnConnction()
    {
        //_connectionToBoss.SetActive(true);
    }

    public bool checkAliveStatus()
    {
        return _isAlive;
    }

    public void respawnSelf()
    {
        _currentHealth = _maxHealth;
        _bodyRef.SetActive(true);
        _isAlive = true;
        sfxPlayed = false;
        _selfWeaponRef.enabled = true;
        _selfWeaponRef.resetWeapon();
    }

    public int getCurrHealth()
    {
        return _currentHealth;
    }

    public void Damage(int dam)
    {
        _currentHealth -= dam;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void setToMaxHealth()
    {
        _currentHealth = _maxHealth;
    }
}

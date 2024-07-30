using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour
{
    
    [SerializeField] private BossHealth _bossHPRef = null;
    [SerializeField] private bool _bossFightActive = false;
    [SerializeField] private bool _bossDefeated = false;
    [SerializeField] private Transform[] _movementPoints;
    private int currentPointIndex = 0;
    [SerializeField] private Transform _currentPoint;
    [SerializeField] private Transform _bossPosition;
    [SerializeField] private Transform _arenaCenter;
    [SerializeField] private Transform _dropPoint;
    [SerializeField] private Animation _bossAnimRef = null;
    [SerializeField] private float _moveSpeed = 1.0f;

    [Header("Boss Attacks")]
    [SerializeField] private GameObject[] _bossWeakpoints;
    [SerializeField] private BossWeapon[] _bossWeapons;
    [SerializeField] private float _basicAttackCooldown = 5f;
    [SerializeField] private float _strongAttackCooldown = 12f;
    [SerializeField] private int _attacksInStrongAttack = 3;
    [SerializeField] private float _timeBetweenShots = 1f;
    [SerializeField] private float basicAttackTimer = 0f;
    [SerializeField] private float strongAttackTimer = 0f;

    [Header("Music Stuff")]
    [SerializeField] private GameObject _mainMusic = null;
    [SerializeField] private GameObject _bossMusic = null;

    [Header("SFX Stuff")]
    [SerializeField] private AudioSource _bossGroan = null;
    [SerializeField] private AudioSource _bossRespawnPop = null;

    [Header("Level Stuff")]
    [SerializeField] private GameObject _leftBossDoor = null;
    [SerializeField] private GameObject _rightBossDoor = null;

    private void Start()
    {
        if (_bossHPRef == null)
            Debug.LogError("Boss HP Reference not assigned!");
        if (_bossAnimRef == null)
            Debug.LogError("Boss Animation Reference not assigned!");


        if (_mainMusic == null)
            Debug.LogError("Main Music not assigned!");
        if (_bossMusic == null)
            Debug.LogError("Boss Music not assigned!");

        if (_bossGroan == null)
            Debug.LogError("Boss Groan SFX not assigned!");
        if (_bossRespawnPop == null)
            Debug.LogError("Boss Respawn Pop not assigned!");

        if (_leftBossDoor == null)
            Debug.LogError("Left boss door not assigned!");
        else
            _leftBossDoor.SetActive(false);
        if (_rightBossDoor == null)
            Debug.LogError("Right boss door not assigned!");
        else
            _rightBossDoor.SetActive(false);

        foreach (GameObject weakpoint in _bossWeakpoints)
            if (weakpoint.GetComponent<BossWeakpoint>() != null)
            {
                weakpoint.GetComponent<BossWeakpoint>().hideConnction();
                weakpoint.SetActive(false);
            }
    }


    private bool immunePlaceholder = true;
    private bool temp = false;
    private bool temp2 = false;
    // Update is called once per frame
    void Update()
    {
        if (!_bossFightActive)
            foreach (GameObject weakpoint in _bossWeakpoints)
                if (weakpoint.GetComponent<BossWeakpoint>() != null)
                    weakpoint.GetComponent<BossWeakpoint>().setToMaxHealth();
        if (_bossFightActive)
        {
            checkWeakpointStatus();
            // put attack check here
            basicAttackTimer += Time.deltaTime;
            strongAttackTimer += Time.deltaTime;

            // attack stuff
            if (strongAttackTimer > _strongAttackCooldown)
            {
                // do strong attack
                //Debug.Log("Boss is attacking Strongly");
                foreach (GameObject weakpoint in _bossWeakpoints)
                    if (weakpoint.GetComponent<BossWeakpoint>() != null)
                        if (weakpoint.GetComponent<BossWeakpoint>().checkAliveStatus() == true)
                            if (weakpoint.GetComponent<BossWeapon>() != null)
                                weakpoint.GetComponent<BossWeapon>().fireStrongAttack(_attacksInStrongAttack, _timeBetweenShots);

                strongAttackTimer = 0f;
                basicAttackTimer = 0f;
            }
            else if (basicAttackTimer > _basicAttackCooldown)
            {
                //Debug.Log("Boss is attacking basic");
                foreach (GameObject weakpoint in _bossWeakpoints)
                    if (weakpoint.GetComponent<BossWeakpoint>() != null)
                        if (weakpoint.GetComponent<BossWeakpoint>().checkAliveStatus() == true)
                            if (weakpoint.GetComponent<BossWeapon>() != null)
                                weakpoint.GetComponent<BossWeapon>().fireBasicAttack();

                basicAttackTimer = 0f;
            }

            // movement and animation stuff
            if (_bossHPRef.checkIsImmune() == true) // if boss is immune to damage
            {
                immunePlaceholder = playBossAnimation("Boss_Idle");
                temp = false;
                temp2 = false;
                // get next point if at current point
                if (_bossPosition.position.Equals(_currentPoint.transform.position))
                {
                    setNextPointFromArray();
                }

                // look at next point
                lookAtCurretPoint();

                // move toward next point
                float step = _moveSpeed * Time.deltaTime;
                _bossPosition.position = Vector3.MoveTowards(_bossPosition.position, _currentPoint.position, step);

            }
            else if (_bossHPRef.checkIsImmune() == false) // if boss is not immune
            {
                if (temp == false)
                {
                    teleportBossToDrop();
                    lookAtCurretPoint();
                    temp = true;
                }

                // move toward point
                float step = (_moveSpeed * 5) * Time.deltaTime;
                _bossPosition.position = Vector3.MoveTowards(_bossPosition.position, _currentPoint.position, step);
                if (_bossPosition.position.Equals(_arenaCenter.transform.position))
                {
                    if (temp2 == false)
                    {
                        temp2 = playBossAnimation("Boss_Down");
                    }
                }
            }
        }
    }

    public void beginBossFight()
    {
        _bossFightActive = true;
        _bossHPRef.beginBossFight();
        foreach (GameObject weakpoint in _bossWeakpoints)
            if (weakpoint.GetComponent<BossWeakpoint>() != null)
            {
                weakpoint.SetActive(true);
                weakpoint.GetComponent<BossWeakpoint>().spawnConnction();
            }

        _bossHPRef.toggleUI(true);
        _mainMusic.SetActive(false);
        _bossMusic.SetActive(true);

        _leftBossDoor.SetActive(true);
        _rightBossDoor.SetActive(true);
    }

    private bool temp3 = false;
    public void endBossFight()
    {
        _bossFightActive = false;
        _bossDefeated = true;

        //temp3 = playBossAnimation("Boss_Death");
        StartCoroutine(bossDeath());

        foreach (GameObject weakpoint in _bossWeakpoints)
            if (weakpoint.GetComponent<BossWeakpoint>() != null)
                weakpoint.GetComponent<BossWeakpoint>().hideConnction();

        _bossHPRef.toggleUI(false);
        _mainMusic.SetActive(true);
        _bossMusic.SetActive(false);

        _leftBossDoor.SetActive(false);
        _rightBossDoor.SetActive(false);
    }

    public bool checkBossFightActive()
    {
        return _bossFightActive;
    }

    public bool checkIfBossDefeated()
    {
        return _bossDefeated;
    }
    
    private void checkWeakpointStatus()
    {
        foreach (GameObject weakpoint in _bossWeakpoints)
        {
            if (weakpoint.GetComponent<BossWeakpoint>() != null)
            {
                if (weakpoint.GetComponent<BossWeakpoint>().checkAliveStatus())
                {
                    _bossHPRef.isImmune(true);
                    break;
                }
                else if (_bossHPRef.checkIsImmune() == true)
                {
                    /* do the drop
                     * 
                     * 
                     */
                    _bossHPRef.isImmune(false);

                    playBossGroan();
                }
            }
        }
    }

    public void playBossGroan()
    {
        if (_bossGroan.isPlaying == true)
        {
            _bossGroan.Stop();
        }
        _bossGroan.Play();
    }

    public void respawnWeakpoints()
    {
        foreach (GameObject weakpoint in _bossWeakpoints)
            if (weakpoint.GetComponent<BossWeakpoint>() != null)
                weakpoint.GetComponent<BossWeakpoint>().respawnSelf();
        _bossRespawnPop.Play();
    }

    public bool playBossAnimation(string animName)
    {
        _bossAnimRef.Play(animName);
        return true;
    }

    private void teleportBossToDrop()
    {
        _bossPosition.position = _dropPoint.position;
        _currentPoint = _arenaCenter;
    }

    private void setNextPointFromArray()
    {
        currentPointIndex++;

        if (currentPointIndex >= _movementPoints.Length)
            currentPointIndex = 0;

        _currentPoint = _movementPoints[currentPointIndex];
    }

    private void lookAtCurretPoint()
    {
        Vector3 dif = _currentPoint.position - _bossPosition.position;
        float rotationX = Mathf.Atan2(dif.z, dif.y) * Mathf.Rad2Deg;
        _bossPosition.rotation = Quaternion.Euler(rotationX - 90, 90, -90);
    }

    private IEnumerator bossDeath()
    {
        _bossAnimRef.Play("Boss_Death");
        while (_bossAnimRef.isPlaying)
            yield return null;

        _bossHPRef.disableBossBody();
    }
}

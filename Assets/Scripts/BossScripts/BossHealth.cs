using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private EnemyRangeScript _playerRangeRef = null;
    
    [Header("Boss Setup")]
    [SerializeField] private GameObject _bodyRef = null;
    [SerializeField] private BossAI _bossAIRef = null;
    //[SerializeField] private Animation _bossAnimRef = null;

    [SerializeField] private Slider _healthBar = null;
    [SerializeField] private Canvas _bossUI = null;
    [SerializeField] private Image _bossImmortalImage = null;

    [SerializeField] private int _bossMaxHealth = 30;
    [SerializeField] private int _bossCurrHealth = 30;

    [SerializeField] private bool bossFightActive = false;
    [SerializeField] private bool isImmuneToDamage = true;

    private bool firstPhaseComplete = false;        // 100 -> 75 (true at 75)
    private bool secondPhaseComplete = false;       // 75 -> 50 (true at 50)
    private bool thirdPhaseComplete = false;        // 50 -> 25 (true at 25)
    private bool bossDead = false;                  // 25 -> 0 (true at 0)

    private bool downedAnimHasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_playerRangeRef == null)
            Debug.LogError("Player Range Reference is not assigned!");

        if (_bodyRef == null)
            Debug.LogError("Boss Body is not assinged!");

        if (_bossAIRef == null)
            _bossAIRef = GetComponentInParent<BossAI>();

        /*
        if (_bossAnimRef == null)
            _bossAnimRef.GetComponentInChildren<Animation>();
        */

        if (_healthBar == null)
            Debug.LogError("Boss Health Bar is not assigned!");
        else
        {
            _healthBar.GetComponent<Slider>().maxValue = _bossMaxHealth;
            _healthBar.GetComponent<Slider>().value = _bossMaxHealth;
        }

        if (_bossUI == null)
            Debug.LogError("Boss UI is not assigned!");
        else
            _bossUI.gameObject.SetActive(false);

        if (_bossImmortalImage == null)
            Debug.LogError("Boss Immortal Image is not assigned!");
        else
            _bossImmortalImage.gameObject.SetActive(true);

        _bossCurrHealth = _bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossFightActive)
        {
            float bossHPPercent = ((_bossCurrHealth * 1f) / (_bossMaxHealth * 1f)) * 100f;
            //Debug.Log("Boss HP Percent: " + bossHPPercent.ToString());

            // if boss is downed
            if (!isImmuneToDamage)
            {
                if (downedAnimHasPlayed == false)
                {
                    // _bossAnimRef.Play("Boss_Down");
                    // downedAnimHasPlayed = _bossAnimRef.Play("Boss_Down");
                    downedAnimHasPlayed = _bossAIRef.playBossAnimation("Boss_Down");
                }

                if (bossHPPercent <= 75f && firstPhaseComplete == false)
                {
                    firstPhaseComplete = true;
                    _bossAIRef.respawnWeakpoints();
                    downedAnimHasPlayed = false;
                }
                else if (bossHPPercent <= 50f && secondPhaseComplete == false)
                {
                    secondPhaseComplete = true;
                    _bossAIRef.respawnWeakpoints();
                    downedAnimHasPlayed = false;
                }
                else if(bossHPPercent <= 25f && thirdPhaseComplete == false)
                {
                    thirdPhaseComplete = true;
                    _bossAIRef.respawnWeakpoints();
                    downedAnimHasPlayed = false;
                }
                else if(bossHPPercent <= 0f && bossDead == false)
                {
                    bossDead = true;
                    //_bodyRef.SetActive(false);
                    // call out to boss ai to disable all connections to boss

                    _playerRangeRef.enemyContact = false;
                    _bossAIRef.endBossFight();
                }
            }
        }
    }


    public void beginBossFight()
    {
        //_bossAnimRef.Play("Boss_Entrance");

        bossFightActive = _bossAIRef.playBossAnimation("Boss_Entrance");
    }

    public void isImmune(bool var)
    {
        isImmuneToDamage = var;
        _bossImmortalImage.gameObject.SetActive(var);
    }

    public void Damage(int damage)
    {
        if (!isImmuneToDamage)
        {
            _bossCurrHealth -= damage;
            _healthBar.value = _bossCurrHealth;
        }
    }

    public void toggleUI(bool toggle)
    {
        _bossUI.gameObject.SetActive(toggle);
    }

    public int getCurrHealth()
    {
        return _bossCurrHealth;
    }

    public bool checkIsImmune()
    {
        return isImmuneToDamage;
    }

    public void disableBossBody()
    {
        _bodyRef.SetActive(false);
    }
}

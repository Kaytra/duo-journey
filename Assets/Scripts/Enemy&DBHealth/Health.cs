using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] AudioSource _audsou = null;
    [SerializeField] AudioClip _damaged = null;
    [SerializeField] GameObject Death = null;
    [SerializeField] GameObject _Body = null;
    [SerializeField] GameObject healthPickup = null;
    public Slider barSlider = null;
    [SerializeField] GameObject barcanvas = null;
    [SerializeField] bool _canSpawnHealth = false;
    public int currHealth = 1;
    public int maxHealth = 2;
    public Transform myTrans;
    public Transform startTrans;
    public bool isDestructibleWall = false;

    private void Start()
    {
        currHealth = maxHealth;
        barSlider.maxValue = maxHealth;
        barSlider.value = currHealth;
        startTrans = _Body.GetComponent<Transform>();
    }

    void Update()
    {
        myTrans = gameObject.transform;
    }

    public void Damage(int damage)
    {
        _audsou.clip = _damaged;
        _audsou.Play();
        currHealth -= damage;
        barSlider.value = currHealth;
        barcanvas.SetActive(true);

        if (currHealth <= 0)
        {
            if(_canSpawnHealth == true)
            {
                SpawnHealth();
            }
            Instantiate(Death, myTrans.position, Death.transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void SpawnHealth()
    {
        int chance = Random.Range(1, 10);
        if (chance <= 2)
        {
            Instantiate(healthPickup, myTrans.position, healthPickup.transform.rotation);
        }
    }

    public void KillEnemy()
    {
        currHealth = 0;
        Instantiate(Death, myTrans.position, myTrans.rotation);
        gameObject.SetActive(false);
    }
}



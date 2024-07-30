using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRangeScript : MonoBehaviour
{
    [Header("Enemy Tracking")]
    private GameObject[] allEnemies;
    public Transform closestEnemy;
    public bool enemyContact;
    public GameObject orbWeapon;

    [Header("Player Stuff")]
    public GameObject player;
    public GameObject spark;
    [SerializeField] ParticleSystem attackSpark;
    GameObject target; 

    private AudioSource zap;

    private Color targetColor;

    public bool gameIsPausedOrPlayerDead = false;

    [Header("Attack Stuff")]
    public GameObject image;
    public AudioSource NoAttack;
    [SerializeField] private Slider _attackCooldownSlider;
    private bool canAttack = true;
    private float attackTimer = .5f;
    private float Timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
        zap = spark.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        canAttack = true;
        image.SetActive(false);

        if (_attackCooldownSlider == null)
            Debug.LogError("Attack Cooldown Slider is not assigned!");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsPausedOrPlayerDead)
        {
            ///attack input
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (canAttack == false)
                {
                    NoAttack.Play();
                    image.SetActive(true);
                }

                if (canAttack == true)
                {
                    Attack();
                    Debug.Log("attack");
                }
            }

            if (closestEnemy == null)
            {
                spark.transform.position = player.transform.position;
            }
            if (closestEnemy != null)
            {
                spark.transform.position = closestEnemy.position + closestEnemy.TransformDirection(new Vector3(0, 2, 0));
            }

            if(canAttack == false)
            {
                Timer += Time.deltaTime;
                // slider code
                _attackCooldownSlider.value = Timer / attackTimer;

                if(Timer >= attackTimer)
                {
                    Debug.Log("canAttack is true");
                    image.SetActive(false);
                    canAttack = true;
                    Timer = 0;
                }
            }

            if (enemyContact == false)
                closestEnemy = null;
        }
    }

    ///needs enemy health script
    private void Attack()
    {
        if (enemyContact)
        {
            if (closestEnemy != null)
            {
                if (closestEnemy.GetComponent<Health>() != null)
                {
                    if (closestEnemy.GetComponent<Health>().currHealth >=1)
                    {
                        closestEnemy.gameObject.GetComponent<Health>().Damage(1);
                        attackSpark.Play();
                        orbWeapon.gameObject.GetComponent<OrbWeaponScript>().WeaponSpark();
                        zap.Play();
                        //Debug.Log("damageDelt");
                        canAttack = false;
                    }
                }

                //else if (closestEnemy.GetComponent<Health>() == null)
                //{
                //closestEnemy = null;
                //enemyContact = false;
                //}
                else if (closestEnemy.GetComponentInParent<BossWeakpoint>() != null)
                {
                    closestEnemy.gameObject.GetComponentInParent<BossWeakpoint>().Damage(1);
                    attackSpark.Play();
                    orbWeapon.gameObject.GetComponent<OrbWeaponScript>().WeaponSpark();
                    zap.Play();
                    canAttack = false;
                }
                else if (closestEnemy.GetComponentInParent<BossHealth>() != null)
                {
                    closestEnemy.GetComponentInParent<BossHealth>().Damage(1);
                    attackSpark.Play();
                    orbWeapon.gameObject.GetComponent<OrbWeaponScript>().WeaponSpark();
                    zap.Play();
                    canAttack = false;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.isTrigger != true && other.CompareTag("Enemy") && other.gameObject.activeInHierarchy == true)
        {
            if (closestEnemy != null)
            {
                if (closestEnemy.GetComponent<MeshRenderer>() != null)
                {
                    closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
                }
            }
            closestEnemy = GetClosestEnemy();
            if (closestEnemy.GetComponent<MeshRenderer>() != null)
            {
                targetColor = closestEnemy.GetComponent<MeshRenderer>().material.color;
                //closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
                closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
            }
            else if (closestEnemy.GetComponent<Charger>() != null)
            {
                MeshRenderer[] chargerMeshes = closestEnemy.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer cmesh in chargerMeshes)
                {
                    cmesh.material.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
                }
            }
            else if (closestEnemy.GetComponent<SlugEnemyWaypoint>() != null)
            {
                MeshRenderer[] slugMeshes = closestEnemy.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer smesh in slugMeshes)
                {
                    smesh.material.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
                }
            }
            enemyContact = true;
        }

        if (other.isTrigger != true && other.CompareTag("BossWeakpoint") && other.gameObject.activeInHierarchy == true)
        {
            if (closestEnemy != null)
                closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
            closestEnemy = GetClosestWeakpoint();
            targetColor = closestEnemy.GetComponent<MeshRenderer>().material.color;
            //closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
            closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
            enemyContact = true;
        }
        
        if (other.isTrigger != true && other.CompareTag("BossBody") && other.gameObject.activeInHierarchy == true)
        {
            if (other.GetComponentInParent<BossHealth>().checkIsImmune() == false)
            {
                if (closestEnemy != null)
                    closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
                closestEnemy = GetBossBody();
                targetColor = closestEnemy.GetComponent<MeshRenderer>().material.color;
                //closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 1);
                closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1));
                enemyContact = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.isTrigger != true && other.CompareTag("Enemy"))
        {
            enemyContact = false;
            if (closestEnemy.GetComponent<MeshRenderer>() != null)
            {
                closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
            }
        }
        if (other.isTrigger != true && other.CompareTag("BossWeakpoint"))
        {
            enemyContact = false;
            closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
        }
        if (other.isTrigger != true && other.CompareTag("BossBody"))
        {
            if (other.GetComponentInParent<BossHealth>() == true)
            {
                if (other.GetComponentInParent<BossHealth>().checkIsImmune() == false)
                {
                    enemyContact = false;
                    closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (closestEnemy != null)
        {
            if (closestEnemy.GetComponent<MeshRenderer>() != null)
            {
                closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = targetColor;
            }
        }
    }

    public Transform GetClosestEnemy()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in allEnemies)
        {
            //if(go.activeInHierarchy == true)
            //{
            //    float currentDistance;
            //    currentDistance = Vector3.Distance(transform.position, go.transform.position);
            //    if (currentDistance < closestDistance)
            //    {
            //        closestDistance = currentDistance;
            //        trans = go.transform;
            //    }
            //}
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }

    public Transform GetClosestWeakpoint()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("BossWeakpoint");
        float closetDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject wp in allEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, wp.transform.position);
            if (currentDistance < closetDistance)
            {
                closetDistance = currentDistance;
                trans = wp.transform;
            }
        }
        return trans;
    }

    public Transform GetBossBody()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("BossBody");
        Transform trans = null;
        trans = temp.transform;

        return trans;
    }

    void StopSpark()
    {
        spark.SetActive(false);
    }

    public void KillAllHostile()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in allEnemies)
        {
            go.GetComponent<Health>().KillEnemy();
        }
    }
}

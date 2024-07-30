using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWeaponScript : MonoBehaviour
{
    private GameObject player;
    private GameObject orb;
    private AudioSource sparkAudio;
    private GameObject sight;
    [SerializeField] private Transform target;
    private Transform floatPos;
    public GameObject floatPoint;
    public float followSpeed;
    [SerializeField] ParticleSystem spark;
    // Start is called before the first frame update
    void Start()
    {
        sparkAudio = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        orb = gameObject.GetComponent<GameObject>();
        sight = GameObject.FindGameObjectWithTag("Player Target");
        floatPos = floatPoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sight.GetComponent<EnemyRangeScript>().closestEnemy != null)
        {
            target = sight.GetComponent<EnemyRangeScript>().closestEnemy;
        }
        else
        {
            target = null;
        }


        float followVel = followSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, floatPos.position, followVel);

        if(target != null)
        {
            Vector3 targetdir = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetdir + new Vector3(0,180,0));
            transform.rotation = rotation;
        }
        if (target == null)
            lookAtPlayer();
        
        else if ( target.GetComponent<Health>() == true)
            if (target.GetComponent<Health>().currHealth <= 0)
                lookAtPlayer();

        else if (target.GetComponentInParent<BossWeakpoint>())
            if (target.GetComponentInParent<BossWeakpoint>().getCurrHealth() <= 0)
                lookAtPlayer();

        else if (target.GetComponentInParent<BossHealth>())
            if (target.GetComponentInParent<BossHealth>().getCurrHealth() <= 0)
                lookAtPlayer();
    }

    public void WeaponSpark()
    {
        spark.Play();
        sparkAudio.Play();
    }

    private void lookAtPlayer()
    {
        Vector3 playerdir = player.GetComponent<Transform>().position - transform.position;
        Quaternion altRot = Quaternion.LookRotation(playerdir + new Vector3(0,180,0));
        transform.rotation = altRot;
    }
}

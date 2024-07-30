using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public float maxSpirit;
    public float curSpirit;
    public float TickTime;
    public float holdTime;
    public float holdCount;
    public bool canSLink;
    private GameObject player;
    public GameObject cantLink;
    private AudioSource linkSound;
    public bool checkpnt, recall;
    private GameObject[] allInteractable;
    private GameObject collectMngr;
    public GameObject spiritFillEffect;

    [SerializeField] private SceneMaster sceneMstr = null;

    //private Transform playerLoc;
    public int playerHealth;
    public GameObject spawn;
    public GameObject playerBody;
    public GameObject particleSpawn;
    [SerializeField] ParticleSystem pointLocation;
    //[SerializeField] ParticleSystem pointSet;
    public GameObject chargeEffect;

    // Start is called before the first frame update
    void Start()
    {
        curSpirit = 0;
        maxSpirit = 100;
        player = GameObject.FindGameObjectWithTag("Player");
        spawn.GetComponent<Transform>().position = particleSpawn.GetComponent<Transform>().position;
        pointLocation.Play();
        playerHealth = player.GetComponent<PlayerHealth>().health; /*Possible Issue*/
        cantLink.SetActive(false);
        linkSound = gameObject.GetComponent<AudioSource>();
        checkpnt = false;
        recall = false;
        spiritFillEffect.SetActive(false);
        if (GameObject.FindGameObjectsWithTag("CollectableManager") != null)
            collectMngr = GameObject.FindGameObjectWithTag("CollectableManager");
        else
            collectMngr = null;

        if (sceneMstr == null)
            sceneMstr = GameObject.Find("SceneMaster").GetComponent<SceneMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerHealth = player.GetComponent<PlayerHealth>().health; /*Possible Issue*/
        if (curSpirit > maxSpirit)
        {
            curSpirit = maxSpirit;
        }
        if (curSpirit < maxSpirit)
        {
            TickTime -= Time.deltaTime;
            if (TickTime <= 0)
            {
                curSpirit += 1;
                TickTime = 0.1f;
            }
        }
        if (curSpirit >= maxSpirit)
        {
            if (Input.GetKey(KeyCode.E) && holdCount < 1.0f)
            {
                holdTime -= Time.deltaTime;
                if (holdTime <= 0)
                {
                    holdCount += 0.01f;
                    holdTime = 0.01f;
                }
            }
            if (Input.GetKey(KeyCode.E) && holdCount >= 1.0f)
            {
                SpiritLink();
                linkSound.Play();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                chargeEffect.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.E) && holdCount < 1.0f)
            {
                chargeEffect.SetActive(false);
                holdCount = 0;
            }
            //if (Input.GetKey(KeyCode.X))
            //{
            //    playerBody.GetComponent<Transform>().position = spawn.GetComponent<Transform>().position;
            //}
            //if (Input.GetKey(KeyCode.X) && holdCount >= 1.0f)
            //{
            //    Recall();
            //}
            //if (Input.GetKeyUp(KeyCode.X) && holdCount < 1.0f)
            //{
            //    holdCount = 0;
            //}
        }
        if(curSpirit < maxSpirit)
        {
            if (Input.GetKey(KeyCode.E))
            {
                cantLink.SetActive(true);
                Invoke("CantLinkOff", 1.5f);
            }
        }
        /*if (playerHealth <= 0)
        {

            Invoke("Respawn", 2.2f);
        }*/
    }

    private void FixedUpdate()
    {
        if (curSpirit == maxSpirit)
        {
            spiritFillEffect.SetActive(true);
            Invoke("EndSpiritEffect", 1.0f);
        }
    }

    public void Respawn()
    {
        player.GetComponent<PlayerHealth>().PlayerRespawn();
        playerBody.GetComponent<Transform>().position = spawn.GetComponent<Transform>().position;
        //pointSet.Play();
        playerHealth = 4;
        playerBody.GetComponent<CharacterMovement>().impact = Vector2.zero;
        playerBody.SetActive(true);
    }

    public void teleportPlayerToCheckpoint()
    {
        playerBody.GetComponent<Transform>().position = spawn.GetComponent<Transform>().position;
        if (checkpnt == true)
        {
            recall = true;
        }
    }

    public void SpiritLink()
    {
        chargeEffect.SetActive(false);
        checkpnt = true;
        spawn.GetComponent<Transform>().position = particleSpawn.GetComponent<Transform>().position;
        pointLocation.Play();
        holdCount = 0;
        curSpirit = 0;
        if (collectMngr != null)
        {
            collectMngr.GetComponent<CollectableManager>().saveCollected();
            collectMngr.GetComponent<CollectableManager>().saveDoor();
        }
        sceneMstr.setDontRespawn();

    }

    public void EndSpiritEffect()
    {
        spiritFillEffect.SetActive(false);
    }

    public void CantLinkOff()
    {
        cantLink.SetActive(false);
    }
    //public void Recall()
    //{
    //    playerBody.GetComponent<Transform>().position = spawn.GetComponent<Transform>().position;
    //    pointLocation.Play();
    //    holdCount = 0;
    //    curSpirit = 0;
    //}


}
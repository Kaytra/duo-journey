using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushandpull : MonoBehaviour
{
    public bool ishere;

    public bool ispressed;

    [SerializeField] private GameObject _promptText;

    public GameObject block;

    public GameObject holder;

    public GameObject player;

    public AudioSource Pickup;

    public AudioSource Putdown;

    public AudioSource Slide;

    Vector3 originalPos;

    CharacterMovement CharacterMove;


    private float jump = 0;
    bool dragged = false;

    // Start is called before the first frame update
    void Awake()
    {
        originalPos = block.transform.position;
        //CharacterMove = FindObjectOfType<CharacterMovement>();
        CharacterMove = player.GetComponent<CharacterMovement>();
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Player"))
        {
            ishere = true;
            _promptText.SetActive(true);

            // CharacterMove.isGrounded = false;
        }

        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            ishere = false;
            _promptText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().health == 0)
        {
            block.transform.position = originalPos;
        }
        if (Input.GetKeyDown(KeyCode.W) && ispressed == false & ishere == true)

        {
            SetMovability();
            CharacterMove.jumpForce = 0;

            //if (CompareTag ("Ground"))
            //{
               // Slide.Play();
            //}
        }
        else if (Input.GetKeyUp(KeyCode.W) && ispressed == true)
        {
            RegularMovability();
            CharacterMove.jumpForce = 14;
        }

    }

   public  void SetMovability()
    {
        block.transform.SetParent(player.transform);
        GetComponent<Rigidbody>().useGravity = false;
        Pickup.Play();
        //ishere = true;
        ispressed = true;
        Slide.Play();
    }

    public void RegularMovability()
    {
        block.transform.SetParent(holder.transform);
        GetComponent<Rigidbody>().useGravity = true;
        Putdown.Play();
        //ishere = false;
        ispressed = false;
    }
}

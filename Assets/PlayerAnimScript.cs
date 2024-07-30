using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimScript : MonoBehaviour
{
    Animator anim;
    GameObject player;

    public bool grounded;
    public float move;
    public int health;
    //int walkHash = Animator.StringToHash("Player_Walk");
    int jumpHash = Animator.StringToHash("Jump");
    //int deathHash = Animator.StringToHash("Player_Death");
    //int IdleHash = Animator.StringToHash("Player_Idle");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        grounded = player.GetComponent<CharacterMovement>().hasJustLanded;
        anim.SetBool("Grounded", grounded);
        move = player.GetComponent<CharacterMovement>().movementDirection;
        anim.SetFloat("Speed", move);
        health = player.GetComponent<PlayerHealth>().health;
        anim.SetInteger("Health", health);

        if(grounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpHash);
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    anim.SetTrigger(jumpHash);
        //}
        //anim.SetFloat("Speed", move);
    }
}

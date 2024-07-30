using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    public float gravityScale;

    public CharacterController controller;

    private Vector3 moveDirection;

    private Vector3 lastMotion;

    public bool hasJustLanded = false;

    private float timer = 0;

    public float movementDirection;
    public bool isGrounded = false;
    public bool facingRight = true;
    public bool gameIsPausedOrPlayerDead = false;

    public Transform closestKock;
    private GameObject[] knockObj;

    private AudioSource jumpSound;
    public GameObject jumpSource;

    private AudioSource landSound;
    public GameObject landSource;

    private AudioSource knockSound;
    public GameObject knockSource;

    public float fallMultiplier;

    //private Vector3 playerFeet = new Vector3(0, -1, 0);
    private RaycastHit hit;

    private bool touchWall = false;
    public Vector2 impact = Vector2.zero;
    private int maxFallSpeed = -18;
    
    // Start is called before the first frame update
    void Start()
    {
        closestKock = null;
        landSound = landSource.GetComponent<AudioSource>();
        jumpSound = jumpSource.GetComponent<AudioSource>();
        knockSound = knockSource.GetComponent<AudioSource>();
        //baseSpeed = movementSpeed;
        controller = GetComponent<CharacterController>();

        Vector3 pos = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!gameIsPausedOrPlayerDead)
        {
            Jump();

            if (controller.isGrounded == false)
            {
                moveDirection.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
            }

            moveDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, moveDirection.y, 0f);

            if (GetComponent<PlayerHealth>().health <= 0)
            {
                impact = new Vector2(0,0);
            }

            if (moveDirection.y <= maxFallSpeed)
            {
                moveDirection.y = maxFallSpeed;
            }

            if (impact.magnitude > 0.2F)
            {
                controller.Move(impact * Time.deltaTime * 3.5f);

                impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
            }
        }
        closestKock = GetClosestKnock();
    }

    void FixedUpdate()
    {
        if (!gameIsPausedOrPlayerDead)
        {
            controller.Move(moveDirection * Time.deltaTime);

            if (controller.isGrounded)
            {
                if (!hasJustLanded)
                {
                    hasJustLanded = true;
                    landSound.Play();
                }
            }
            else
            {
                hasJustLanded = false;
            }

            movementDirection = Input.GetAxis("Horizontal");
            if (movementDirection < 0.0f && facingRight == true)
            {
                RotatePlayer();
                facingRight = !facingRight;
            }
            if (movementDirection > 0.0f && facingRight == false)
            {
                RotatePlayer();
                facingRight = !facingRight;
            }
        }
    }

    void RotatePlayer()
    {
        if (facingRight == false)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    void Jump()
    {

        if (controller.isGrounded == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                jumpSound.Play();
                //secondJumpAvail = true;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && touchWall == true)
            {
                moveDirection.y = jumpForce;
                jumpSound.Play();
                touchWall = false;
            }
            else
            {
                moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
            }
        }

        lastMotion = moveDirection;
    }

    void KnockBack()
    {
        closestKock = GetClosestKnock();
        Vector2 knockDir = (gameObject.GetComponent<Transform>().position - closestKock.position).normalized;
        knockSound.Play();
        if (controller.isGrounded)
        {
            impact += knockDir * 6;
        }
        else
        {
            impact += knockDir * 5;
        } 
        if (impact.x == 0)
        {
            impact.x = -1;
        }

        //impact += knockDir.normalized * force / mass;
        gameObject.GetComponent<PlayerHealth>().HurtPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //previously commented out by KW
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
            landSound.Play();
        }
    }

    //previously commented out by KW
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    
    public Transform GetClosestKnock()
    {
        knockObj = GameObject.FindGameObjectsWithTag("knock");
        float nearestDistance = Mathf.Infinity;
        Transform pos = null;

        foreach (GameObject go in knockObj)
        {
            float distance;
            distance = Vector3.Distance(transform.position, go.transform.position);
            if (distance < nearestDistance && go.activeInHierarchy == true)
            {
                nearestDistance = distance;
                pos = go.transform;
            }
        }
        return pos;
    }

    public void Damaged()
    {
        KnockBack();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            touchWall = true;
            gravityScale = 1.25f;
            /*if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                jumpSound.Play();
                gravityScale = 1f;
            }*/
            /*if (Input.GetKey(KeyCode.D) && Input.GetButtonDown("Jump") && facingRight == true)
            {
                Debug.DrawRay(hit.point, hit.normal, Color.blue, 2.0f);
                lastMotion.x = hit.normal.x * movementSpeed;
                moveDirection.y = jumpForce;
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetButtonDown("Jump") && facingRight == false)
            {
                Debug.DrawRay(hit.point, hit.normal, Color.blue, 2.0f);
                lastMotion.x = hit.normal.x * movementSpeed;
                moveDirection.y = jumpForce;
            }*/

        }
        else
        {
            touchWall = false;
            gravityScale = 1.5f;
        }
        if (hit.collider.tag == "knock")
        {
            timer += Time.deltaTime;
            if (timer >= .05)
            {
                KnockBack();
                timer = 0;
            }
        }
        /*if (hit.collider.tag == "Enemy")
        {
            timer += Time.deltaTime;
            if (timer >= .05)
            {
                KnockBack();
                timer = 0;
            }
        }*/

        if (controller.collisionFlags == CollisionFlags.Below)
        {
            if (hit.gameObject.tag == "BouncePanel")
            {
                jumpForce = 20;
            }
            else
            {
                jumpForce = 14;
            }
        }

        /*switch (hit.gameObject.tag)
        {
            case "BouncePanel":
                jumpForce = 20f;
                break;

            case "Ground":
                jumpForce = 14f;
                break;
        }*/
    }
}
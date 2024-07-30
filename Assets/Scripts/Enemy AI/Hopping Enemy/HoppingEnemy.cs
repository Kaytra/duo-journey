using UnityEngine;

public class HoppingEnemy : MonoBehaviour
{
    [SerializeField] AudioClip jump = null;
    [SerializeField] AudioClip land = null;
    private AudioSource mySource = null;
    private string CurrPoint = null;
    private int navIndex;
    public GameObject _player;
    [SerializeField] NavPoints[] mypoints = null;
    public bool _isAttacking = false;
    private bool _isGrounded = false;
    private Rigidbody RB;
    private float jumpsrt = 100;
    private Vector2 newTravelPosition;
    private Transform mytrans;
    private Vector2 trans;
    [SerializeField] float moveDisPerSec = 20;

    private void Start()
    {
        mySource = GetComponent<AudioSource>();
        RB = GetComponent<Rigidbody>();
        mytrans = GetComponent<Transform>();
        newTravelPosition = mypoints[navIndex].transform.position;
        CurrPoint = mypoints[navIndex].name;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1))
        {
            Debug.DrawRay(gameObject.transform.position, Vector3.down, Color.red, 1);
            if (hit.collider.gameObject.tag == "Ground" || hit.collider.gameObject.tag == "Wall")
            {
                if(_isGrounded == false)
                {
                    mySource.clip = land;
                    mySource.Play();
                    _isGrounded = true;
                }
            }
        }
        else
        {
            if (_isGrounded == true)
            {
                mySource.clip = jump;
                mySource.Play();
                _isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isAttacking && _isGrounded == true)
        {
            Vector2 direc = (_player.GetComponent<Transform>().position - mytrans.position).normalized;
            RB.AddForce((direc + new Vector2(0,1.9f)) * jumpsrt, ForceMode.Impulse);
        }
        if (_isAttacking == false && _isGrounded == true)
        {
            mytrans = GetComponent<Transform>();

            float dis = Vector3.Distance(mytrans.position, newTravelPosition);
            if (dis > 0)
            {
                float moveDis = Mathf.Clamp(moveDisPerSec * Time.fixedDeltaTime, 0, dis);

                trans = mytrans.position;

                Vector2 move = (newTravelPosition - trans).normalized * moveDis;
                mytrans.Translate(move, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<NavPoints>() != null && collision.gameObject.name == CurrPoint)
        {
            if(_isAttacking == false)
            {
                ++navIndex;
                if (navIndex >= mypoints.Length)
                {
                    navIndex = 0;
                }
                newTravelPosition = mypoints[navIndex].transform.position;
                CurrPoint = mypoints[navIndex].name;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _player)
        {
            collision.gameObject.GetComponent<CharacterMovement>().Damaged();
        }
    }
}

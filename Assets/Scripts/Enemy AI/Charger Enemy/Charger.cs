using UnityEngine;

public class Charger : MonoBehaviour
{
    public GameObject _player = null;
    [SerializeField] NavPoints[] myPoints = null;
    private string CurrPoint;
    private int navIndex = 0;
    public bool _isAttacking = false;
    public Rigidbody RB;
    private Transform myTrans;
    private Vector3 Destination;
    private Vector3 Trans;
    [SerializeField] float speed = 3;
    private float time = 0;
    private float timer = .24f;
    [SerializeField] private bool isStatic = false;
    
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        if (isStatic == false)
        {
            Destination = myPoints[navIndex].transform.position;
            CurrPoint = myPoints[navIndex].gameObject.name;
            myTrans = GetComponent<Transform>();
        }
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isStatic == false)
        {
            myTrans = GetComponent<Transform>();
            Trans = myTrans.position;
        }
    }

    private void FixedUpdate()
    {
        if (isStatic == false)
        {
            if (_isAttacking == true)
            {
                Vector3 direc = (_player.GetComponent<Transform>().position - myTrans.position).normalized;
                RB.AddForceAtPosition(direc * 3, myTrans.position + direc, ForceMode.Acceleration);
            }
            else
            {
                Vector3 direc = (Destination - Trans).normalized;
                time += Time.fixedDeltaTime;
                //time += Time.deltaTime;
                if (time >= timer)
                {
                    RB.AddForceAtPosition(direc * 1.7f, myTrans.position + direc, ForceMode.Acceleration);
                    time = 0;
                }
            }

            /*if (_isAttacking == false)
            {
                Vector3 direc = (Destination - Trans).normalized;
                time += Time.fixedDeltaTime;
                //time += Time.deltaTime;
                if (time >= timer)
                {
                    RB.AddForceAtPosition(direc * 2, myTrans.position + new Vector3(0 ,1.5f, 0) + direc, ForceMode.Acceleration);
                    time = 0;
                }

                float dis = Vector3.Distance(myTrans.position, Destination);

                if (dis > 0)
                {
                    float moveDis = Mathf.Clamp(speed * Time.fixedDeltaTime, 0, dis);

                    Trans = myTrans.position;

                    Vector2 move = (Destination - Trans).normalized * moveDis;
                    myTrans.Translate(move, Space.World);
                }
            }*/

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isStatic == false)
        {
            if (other.gameObject.GetComponent<NavPoints>() != null && other.gameObject.name == CurrPoint)
            {
                if (_isAttacking == false)
                {
                    ++navIndex;
                    if (navIndex >= myPoints.Length)
                    {
                        navIndex = 0;
                    }
                    Destination = myPoints[navIndex].transform.position;
                    CurrPoint = myPoints[navIndex].name;
                    RB.velocity = new Vector3(0, 0, 0);
                    /*Vector3 direc = (Destination - Trans).normalized;
                    RB.AddForceAtPosition(direc * 4, myTrans.position + direc, ForceMode.Acceleration);*/
                }
            }
        }
    }
}

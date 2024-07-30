using UnityEngine;

public class BeamHazard : MonoBehaviour
{
    public GameObject firingSpot;
    public LineRenderer beam;
    private RaycastHit hit;
    private Vector3 direction;
    [SerializeField] bool FiringUp = false;
    [SerializeField] bool FiringLeft = false;
    [SerializeField] bool FiringRight = false;
    [SerializeField] bool FiringDown = false;
    private float timer = 0;
    private float damageTimer = .05f;

    // Start is called before the first frame update
    void Start()
    {
        direction = firingSpot.transform.TransformDirection(Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(firingSpot.transform.position, direction);
        Debug.DrawRay(firingSpot.transform.position, direction * 25, Color.red);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (FiringUp == true)
            {
                beam.SetPosition(1, new Vector3(0, hit.point.y - firingSpot.transform.position.y, 0));
            }
            if (FiringLeft == true)
            {
                beam.SetPosition(1, new Vector3(0, firingSpot.transform.position.x - hit.point.x, 0));
            }
            if (FiringRight == true)
            {
                beam.SetPosition(1, new Vector3(0, hit.point.x - firingSpot.transform.position.x, 0));
            }
            if (FiringDown == true)
            {
                beam.SetPosition(1, new Vector3(0, firingSpot.transform.position.y - hit.point.y, 0));
            }
            if(hit.collider.tag == "Player")
            {
                timer += Time.deltaTime;
                if (timer >= damageTimer)
                {
                    hit.collider.gameObject.GetComponent<CharacterMovement>().Damaged();
                    timer = 0;
                }
            }
        }
        else
        {
            beam.SetPosition(1, new Vector3(0, 100, 0));
        }
    }
}

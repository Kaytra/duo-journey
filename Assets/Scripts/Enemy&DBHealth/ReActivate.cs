using UnityEngine;

public class ReActivate : MonoBehaviour
{
    public GameObject self;
    private Health myHealth;
    private GameObject player;
    public int health;
    public int playerHealth;
    private bool activated = false;

    [SerializeField] private bool dontRespawn = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myHealth = self.GetComponent<Health>();
    }

    void FixedUpdate()
    {
        if (player.GetComponent<PlayerHealth>().health == 0 && activated == false && dontRespawn == false)
        {
            activated = true;
            Invoke("Activate", 2.2f);
        }
    }

    public void Activate()
    {
        self.transform.position = gameObject.transform.position;
        myHealth.currHealth = myHealth.maxHealth;
        myHealth.barSlider.value = myHealth.currHealth;
        if (myHealth.isDestructibleWall == false)
        {
            self.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        self.SetActive(true);
        activated = false;
    }

    public void setDontRespawn()
    {
        dontRespawn = true;
    }

    public bool getDontRespawn()
    {
        return dontRespawn; // if enemy can respawn, return false. if enemy can resapwn, return true
    }

    public int getCurrHealth()
    {
        return myHealth.currHealth;
    }
}

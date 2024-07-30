using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animation _hingeAnimation;
    [SerializeField] private CollectableManager _collectableManager;
    [SerializeField] private TextMeshProUGUI _collectablesText;
    [SerializeField] private GameObject _promptText;
    [SerializeField] private TextMeshProUGUI _requiredCollectablesText;
    [SerializeField] public int _requiredCollectableCount = 2;
    [SerializeField] private GameObject playerRef = null;
    [SerializeField] public bool doorOpened = false;
    private bool playerInTrigger = false;
    private bool playerNear = false;
    private bool DO_calloutTracker = false;
    public GameObject doorObjective;


    public AudioSource DoorSound;

    private void Start()
    {
        doorObjective = GameObject.FindGameObjectWithTag("DoorManager");
        if (_hingeAnimation == null)
            Debug.LogError("Hinge Animaion is not assigned!");

        if (_collectableManager == null)
            GameObject.Find("CollectableManager");

        if (_collectablesText == null)
            Debug.LogError("Collectables text object is not assigned!");

        if (_requiredCollectablesText == null)
            Debug.LogError("Required Collectables text object is not assigned!");

        _requiredCollectablesText.text = "Required Collectables to open: " + _requiredCollectableCount;
        _requiredCollectablesText.gameObject.SetActive(false);

        if (_promptText == null)
            Debug.LogError("Prompt text object is not assigned!");
        else
            _promptText.SetActive(false);

        if (playerRef == null)
            playerRef = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (playerInTrigger)
        //if (playerNear)
        {
            if (Input.GetKeyDown(KeyCode.E) && _collectableManager.getScore() >= _requiredCollectableCount)
            {
                DoorSound.Play();
                _hingeAnimation.Play();
                //Debug.LogError(this.name + " door is opening!");
                _collectableManager.decreaseScore(_requiredCollectableCount);
                _requiredCollectablesText.gameObject.SetActive(false);
                _promptText.SetActive(false);
                doorOpened = true;
                playerInTrigger = false;
                doorObjective.GetComponent<DoorObjective>().OpenDoor();
                this.GetComponent<BoxCollider>().enabled = false;
                foreach (Transform child in transform)
                {
                    child.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

    public void CloseDoor()
    {
        doorOpened = false;
        gameObject.GetComponent<Transform>().SetPositionAndRotation(gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        doorObjective.GetComponent<DoorObjective>().DoorClosed();
        gameObject.GetComponent<BoxCollider>().enabled = true;
        foreach (Transform child in transform)
        {
            child.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void FixedUpdate()
    {
        /*if (doorOpened == true && DO_calloutTracker == false)
        {
            doorObjective.GetComponent<DoorObjective>().OpenDoor();
            DO_calloutTracker = true;
        }*/
        /*
        RaycastHit hit;
         if (!doorOpened)
        {
            Debug.DrawRay(this.transform.position, playerRef.transform.position - transform.position, Color.green);
            if (Physics.Raycast(transform.position, playerRef.transform.position - transform.position, out hit, 6f))
            {
                if (hit.collider.gameObject.tag == "Player" && !doorOpened)
                {
                    //Debug.Log("Player detected!");
                    playerNear = true;
                    if (_collectableManager.getScore() >= _requiredCollectableCount)
                    {
                        _promptText.SetActive(true);
                    }
                    else if (_collectableManager.getScore() < _requiredCollectableCount)
                    {
                        int collStillNeeded = _requiredCollectableCount - _collectableManager.getScore();
                        _requiredCollectablesText.gameObject.SetActive(true);
                        _requiredCollectablesText.text = "Required Collectables to open: " + collStillNeeded + " more";
                    }
                }
            }
            else
            {
                if (!doorOpened)
                {
                    _requiredCollectablesText.gameObject.SetActive(false);
                    _promptText.SetActive(false);
                    playerNear = false;
                }
            }
        }*/
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !doorOpened)
        {
            if (_collectableManager.getScore() >= _requiredCollectableCount)
            {
                _promptText.SetActive(true);
                playerInTrigger = true;
            }
            else if (_collectableManager.getScore() < _requiredCollectableCount)
            {
                int collStillNeeded = _requiredCollectableCount - _collectableManager.getScore(); 
                _requiredCollectablesText.gameObject.SetActive(true);
                _requiredCollectablesText.text = "Required Collectables to open: " + collStillNeeded + " more";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !doorOpened)
        {
            _requiredCollectablesText.gameObject.SetActive(false); 
            _promptText.SetActive(false);
            playerInTrigger = false;
            this.GetComponent<BoxCollider>().enabled = true;
            foreach (Transform child in transform)
            {
                child.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
    
}

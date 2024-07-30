using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _winScreenUI;

    [Header("Game Master")]
    [SerializeField] private GameMaster _gameMasterRef = null;

    [Header("Player Stuff")]
    [SerializeField] private CharacterMovement _playerControler = null;
    private void Start()
    {
        if (_winScreenUI == null)
            Debug.LogError(this.gameObject.name + " does now have Win Screen UI assigned!");
        else
            _winScreenUI.SetActive(false);

        if (_playerControler == null)
            Debug.LogError("Player Controller is not assigned!");

        if (_gameMasterRef == null)
            _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _winScreenUI.SetActive(true);
            // tell player controller to not move
            _playerControler.gameIsPausedOrPlayerDead = true;
        }
    }

    public void goToMainMenu()
    {
        _gameMasterRef.LoadNextLevel("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryConnector : MonoBehaviour
{
    public GameObject StoryCanvas;

    [SerializeField] private string _nextLevel = "";
    [SerializeField] private CharacterMovement _playerControler = null;
    [SerializeField] private EnemyRangeScript _playerRange = null;
    [SerializeField] private GameMaster _gameMasterRef = null;


    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.SetActive(false);
        if (_gameMasterRef == null)
            _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StoryCanvas.activeInHierarchy)
        {
            Time.timeScale = 0.0f;              // set timescale to 0 if cutscene canvas is not the active ui
            Cursor.visible = true;

            _playerControler.gameIsPausedOrPlayerDead = true;
            _playerRange.gameIsPausedOrPlayerDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StoryCanvas.SetActive(true);
        }
    }

    public void NextLevelButton()
    {
        _gameMasterRef.LoadNextLevel(_nextLevel);
        StoryCanvas.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;              // set timescale to 0 if cutscene canvas is not the active ui
        Cursor.visible = false;

        _playerControler.gameIsPausedOrPlayerDead = false;
        _playerRange.gameIsPausedOrPlayerDead = false;
    }
}

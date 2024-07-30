using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenuUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _pauseMenu = null;
    [SerializeField] private GameObject _optionsMenu = null;
    [SerializeField] private GameObject _controlsMenu = null;
    [SerializeField] private GameObject _tutorialMenu = null;
    [SerializeField] private GameObject _debugMenu = null;
    [SerializeField] private GameObject _nextScenePanel = null;
    [SerializeField] private GameObject _winScreenPanel = null;
    [SerializeField] private GameObject _loseScreenPanel = null;
    [SerializeField] private GameObject _cutSceneCanvas = null;
    [SerializeField] private GameObject _sceneConnectorCanvas = null;
    [SerializeField] private TextMeshProUGUI _levelNameText = null;
    [SerializeField] private GameObject _tutorialSceneConnactor = null;


    [Header("Player Stuff")]
    [SerializeField] private CharacterMovement _playerControler = null;
    [SerializeField] private EnemyRangeScript _playerRange = null;

    [Header("Sounds")]
    [SerializeField] private AudioSource _hoverSFX = null;
    [SerializeField] private AudioSource _errorSFX = null;
    [SerializeField] private AudioSource _clickSFX = null;

    [Header("Level Master")]
    [SerializeField] private SceneMaster _sceneMasterRef;

    [Header("Game Master")]
    [SerializeField] private GameMaster _gameMasterRef;

    private void Start()
    {
        // UI
        if (_pauseMenu == null)
            Debug.LogError("Pause Menu has not been assigned!");
        else
            _pauseMenu.SetActive(false);

        if (_optionsMenu == null)
            Debug.LogError("Options Menu has not been assigned!");
        else 
            _optionsMenu.SetActive(false);

        if (_controlsMenu == null)
            Debug.LogError("Controls Menu has not been assigned!");
        else
            _controlsMenu.SetActive(false);

        if (_tutorialMenu == null)
            Debug.LogError("Tutorial Menu has not been assigned!");
        else
            _tutorialMenu.SetActive(false);

        if (_debugMenu == null)
            Debug.LogError("Debug Menu has not been assigned!");
        else
            _debugMenu.SetActive(false);

        if (_sceneMasterRef.hasStory())
        {
            if (_sceneConnectorCanvas == null)
                Debug.LogError("Scene Connector has not been assigned!");
        }

        if (_sceneMasterRef.hasCutScene())
        {
            if (_cutSceneCanvas == null)
                Debug.LogError("Cut Scene Canvas has not been assigned!");
        }

        if (_levelNameText == null)
            Debug.LogError("Level Name Text has not been assigned!");
        else
            _levelNameText.SetText(_sceneMasterRef.getLevelName());

        // Sound checks
        if (_hoverSFX == null)
            Debug.LogError("Hover SFX has not been assigned!");
        if (_errorSFX == null)
            Debug.LogError("Error SFX has not been assigned!");
        if (_clickSFX == null)
            Debug.LogError("Click SFX has not been assigned!");

        // Player Scripts
        if (_playerControler == null)
            Debug.LogError("Player Controller is not assigned!");

        if (_playerRange == null)
            Debug.LogError("Player's Enemy Range Script is not assigned!");

        if (_gameMasterRef == null)
            _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    private void Update()
    {
        if (!_debugMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))               // if ESC is pressed
            {
                if (_tutorialMenu.activeInHierarchy)
                    toggleTutorialMenu();
                else if (_controlsMenu.activeInHierarchy)
                    toggleControlsMenu();
                else if (_optionsMenu.activeInHierarchy)
                    toggleOptionsMenu();
                else
                    togglePauseMenu();
            }
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
            toggleDebugMenu();

        // will pause everything going on in update
        if (anyMenuOpen())                          // if any ui menu is open 
        {
            Time.timeScale = 0.0f;              // set timescale to 0 if cutscene canvas is not the active ui
            Cursor.visible = true;

            _playerControler.gameIsPausedOrPlayerDead = true;
            _playerRange.gameIsPausedOrPlayerDead = true;
        }
        else if (!anyMenuOpen())                    // if no ui menu is open
        {
            Time.timeScale = 1.0f;                  // set time scale to 1

            if (_sceneMasterRef.hasCutScene())
            {
                if (_cutSceneCanvas.activeInHierarchy == true)
                    Cursor.visible = true;
                else if (_cutSceneCanvas.activeInHierarchy == false)
                    Cursor.visible = false;
            }
            else
                Cursor.visible = false;
            

            _playerControler.gameIsPausedOrPlayerDead = false;
            _playerRange.gameIsPausedOrPlayerDead = false;
        }    
    }

    public void togglePauseMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
    }

    public void toggleOptionsMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
        _optionsMenu.SetActive(!_optionsMenu.activeInHierarchy);
    }

    public void toggleControlsMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeInHierarchy);
        _controlsMenu.SetActive(!_controlsMenu.activeInHierarchy);
    }

    public void toggleTutorialMenu()
    {
        _controlsMenu.SetActive(!_controlsMenu.activeInHierarchy);
        _tutorialMenu.SetActive(!_tutorialMenu.activeInHierarchy);
    }

    public void toggleDebugMenu()
    {
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _controlsMenu.SetActive(false);
        _tutorialMenu.SetActive(false);
        _debugMenu.SetActive(!_debugMenu.activeInHierarchy);
    }

    public void closeAllMenus()
    {
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(false);
        _controlsMenu.SetActive(false);
        _tutorialMenu.SetActive(false);
    }

    public void goToMainMenu()
    {
        _gameMasterRef.LoadNextLevel("MainMenu");
    }

    private bool anyMenuOpen()
    {
        if (_pauseMenu.activeInHierarchy ||
            _optionsMenu.activeInHierarchy ||
            _controlsMenu.activeInHierarchy ||
            _tutorialMenu.activeInHierarchy ||
            _debugMenu.activeInHierarchy ||
            _winScreenPanel.activeInHierarchy ||
            _nextScenePanel.activeInHierarchy)
        {
            return true;
        }
        else if (_sceneConnectorCanvas != null || _tutorialSceneConnactor != null)
        {
            if (_sceneConnectorCanvas != null && _sceneConnectorCanvas.activeInHierarchy)
            {
                return true;
            }
            else if (_tutorialSceneConnactor != null && _tutorialSceneConnactor.activeInHierarchy)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    public void playHoverSFX()
    {
        _hoverSFX.Play();
    }

    public void playErrorSFX()
    {
        _errorSFX.Play();
    }

    public void playClickSFX()
    {
        _clickSFX.Play();
    }
}

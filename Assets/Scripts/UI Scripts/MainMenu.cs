using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _menuButtons = null;
    [SerializeField] private GameObject _creditsMenu = null;
    [SerializeField] private GameObject _optionsMenu = null;
    [SerializeField] private GameObject _controlsMenu = null;
    [SerializeField] private GameObject _tutorialMenu = null;
    [SerializeField] private GameObject _levelSelectMenu = null;

    [Header("Game Master")]
    [SerializeField] private GameMaster _gameMasterRef = null;

    private void Start()
    {
        // if menu buttons is assigned, make sure they are active on start
        if (_menuButtons == null)
            Debug.LogError("Menu Buttons GameObject is not assigned!");
        else
            _menuButtons.SetActive(true);

        if (_creditsMenu == null)
            Debug.LogError("Credits Menu GameObject is not assigned!");
        else
            _creditsMenu.SetActive(false);

        // if options buttons is assigned, make sure they are not active on start
        if (_optionsMenu == null)
            Debug.LogError("Options Buttons GameObject is not assigned!");
        else
            _optionsMenu.SetActive(false);

        // if controls buttons is assigned, make sure they are not active on start
        if (_controlsMenu == null)
            Debug.LogError("Controls Buttons GameObject is not assigned!");
        else
            _controlsMenu.SetActive(false);

        // if tutorial menu is assigned, make sure they are not active on start
        if (_tutorialMenu == null)
            Debug.LogError("Tutorial Menu Game Object is not assigned!");
        else
            _tutorialMenu.SetActive(false);

        // if level select menu is assigned, make sure they are not active on start
        if (_levelSelectMenu == null)
            Debug.LogError("Level Select Menu GameObject is not assigned!");
        else
            _levelSelectMenu.SetActive(false);

        _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    public void LoadNextLevel(string levelSceneName)
    {
        _gameMasterRef.LoadNextLevel(levelSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    /*
    public void LoadGame(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }

    public void LoadLevel(string LevelScene)
    {
        SceneManager.LoadScene(LevelScene);
    }

    public void LoadCredits(string CreditsScene)
    {
        SceneManager.LoadScene(CreditsScene);
    }
    */
    public void openMenu(GameObject menuPanel)
    {
        if (menuPanel == null)
            Debug.LogError("Menu Panel has not been assigned!");
        else
        {
            _menuButtons.SetActive(false);
            menuPanel.SetActive(true);
        }
    }

    public void closeMenu(GameObject menuPanel)
    {
        if (menuPanel == null)
            Debug.LogError("Menu Panel has not been assigned!");
        else
        {
            _menuButtons.SetActive(true);
            menuPanel.SetActive(false);
        }
    }
}

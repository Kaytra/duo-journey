using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [Header("UI")]
    public GameObject loadingScreenObj;
    public Slider slider;
    public GameObject startScreen;
    public TextMeshProUGUI loadingTip;
    [Header("Data")]
    [SerializeField] private string _currentScene = "MainMenu";
    [SerializeField] private string prevousScene = "";
    private bool gameStarted = false;
    [SerializeField] private int _loadingDelay = 2;
    [Header("Stuff")]
    [SerializeField] private GameObject _tempCamera = null;

    [Header("Loading Screen Tips")]
    private Dictionary<string, string> _loadingScreenTips = new Dictionary<string, string>();
    

    AsyncOperation async;
    public void Start()
    {
        populateLoadingTips();
        startScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKey && gameStarted == false)
        {
            startScreen.SetActive(false);
            gameStarted = true;
            LoadLevel();
        }

    }

    public void LoadLevel()
    {
        StartCoroutine(LoadingScreen());
    }

    public void LoadNextLevel(string nextScene)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameMaster"));
        prevousScene = _currentScene;
        _currentScene = nextScene;
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);

        Cursor.visible = true;

        // display loading tip for next level
        displayLoadingTip();

        // reset loading bar
        slider.value = 0f;

        yield return new WaitForSecondsRealtime(_loadingDelay);
        //Debug.Log("Loading Delay over");
        if (prevousScene != "")
        {
            Debug.Log("Unloading: " + prevousScene);
            SceneManager.UnloadSceneAsync(prevousScene);
        }
        _tempCamera.SetActive(true);

        async = SceneManager.LoadSceneAsync(_currentScene,LoadSceneMode.Additive);
        async.allowSceneActivation = false;

        yield return new WaitForSecondsRealtime(_loadingDelay);

        while (async.isDone == false)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progress;

            if (async.progress == 0.9f)
            {
                yield return new WaitForSecondsRealtime(_loadingDelay);
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            _tempCamera.SetActive(false);
            loadingTip.text = "Tip text. If you see this, some code failed";
            yield return null;
        }
    }

    public void disableLoadingScreen()
    {
        loadingScreenObj.SetActive(false);
    }

    public void setActiveLevel(string activeLevel)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(activeLevel));
        _currentScene = activeLevel;
    }

    private void populateLoadingTips()
    {
        _loadingScreenTips.Add("","");
        _loadingScreenTips.Add("PrototypeLevel10_Dungeon_KMW", "Warning! If you have arachnophobia, once the level loads, exit the game immediately!");
    }

    public void displayLoadingTip()
    {
        string loadTip;
        if (loadingTip != null)
        {
            if (_loadingScreenTips.TryGetValue(_currentScene, out loadTip))
            {
                loadingTip.text = loadTip;
            }
            else
            {
                loadingTip.text = "";
            }
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    private bool playerInTrigger = false;
    private IEnumerator coroutine;

    [Header("UI")]
    [SerializeField] private GameObject _loadingNextSceneUI;
    [SerializeField] private string _nextScene;
    [SerializeField] private int _loadTime = 3;

    [Header("Player Stuff")]
    [SerializeField] private CharacterMovement _playerControler;

    private void Start()
    {
        if (_loadingNextSceneUI == null)
            Debug.LogError(this.gameObject.name + " does not have Loading Next Scene UI assigned!");
        else
            _loadingNextSceneUI.SetActive(false);

        if (_playerControler = null)
            Debug.LogError("Player Controller is not assigned!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //_playerControler.gameIsPausedOrPlayerDead = true;
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        _loadingNextSceneUI.SetActive(true);
        yield return new WaitForSecondsRealtime(_loadTime);
        if (_nextScene != "")
            SceneManager.LoadScene(_nextScene);
        else if (_nextScene == "")
            Debug.LogError(this.name + " does not have a next scene set!");

        StopCoroutine(LoadNextScene());
    }
}

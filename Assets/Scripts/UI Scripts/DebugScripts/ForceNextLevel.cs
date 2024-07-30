using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceNextLevel : MonoBehaviour
{
    [SerializeField] private GameMaster _gameMasterRef;

    private void Start()
    {
        _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }
    public void forceNextLevel(string nextScene)
    {
        if (nextScene == "")
        {
            Debug.LogError("Next Scene is either not assigned, or this is the last level!");
            gameObject.GetComponent<DebugPrint>().ErrorSound();
        }
        else
        {
            _gameMasterRef.LoadNextLevel(nextScene);
            gameObject.GetComponent<DebugPrint>().ClickSound();
        }
    }
}

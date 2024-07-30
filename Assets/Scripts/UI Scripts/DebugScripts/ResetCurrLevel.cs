using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCurrLevel : MonoBehaviour
{
    [SerializeField] private GameMaster _gameMasterRef;
    [SerializeField] private SceneMaster _sceneMasterRef;
    private void Start()
    {
        _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        if (_sceneMasterRef == null)
            Debug.LogError("Debug Menu: Scene Master Ref is not assigned! Assign the Scene Master in the Inspector!");
    }
    public void resetCurrLevel()
    {
        _gameMasterRef.LoadNextLevel(_sceneMasterRef.getLevelName());
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] private GameMaster _gameMasterRef = null;

    private void Start()
    {
        _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }
    public void mainMenu(string mainMenuScene)
    {
        _gameMasterRef.LoadNextLevel(mainMenuScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    [SerializeField] private string _sceneName = "";
    [SerializeField] private GameMaster _gameMasterRef = null;
    [SerializeField] private bool _isMenuScene = false;
    [SerializeField] private bool _hasCutscene = true;
    [SerializeField] private bool _hasStory = true;

    [SerializeField] private ReActivate[] m_Respawnables;

    // Start is called before the first frame update
    void Start()
    {
        //_sceneName = SceneManager.GetActiveScene().name;

        _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
        _gameMasterRef.setActiveLevel(_sceneName);
        if (_isMenuScene == false)
            Cursor.visible = false;
        _gameMasterRef.disableLoadingScreen();

    }

    public string getLevelName()
    {
        return _sceneName;
    }

    public bool hasCutScene()
    {
        return _hasCutscene;
    }

    public bool hasStory()
    {
        return _hasStory;
    }

    public void setDontRespawn()
    {
        foreach (ReActivate resp in m_Respawnables)
        {
            if (resp.getCurrHealth() == 0)
            {
                Debug.Log("setting " + resp.gameObject.name + " to not respawn");
                resp.setDontRespawn();
            }
        }
    }
}

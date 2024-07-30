using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneTrigger_V2 : MonoBehaviour
{
    [SerializeField] private GameMaster _gameMasterRef = null;
    [SerializeField] private string _nextLevel = "";

    private void Start()
    {
        if (_gameMasterRef == null)
            _gameMasterRef = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //_gameMasterRef.LoadScreenExample();
            _gameMasterRef.LoadNextLevel(_nextLevel);
        }
    }
}

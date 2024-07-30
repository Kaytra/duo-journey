using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAlt : MonoBehaviour
{
    [SerializeField] private CharacterMovement _playerRef = null;
    [SerializeField] private GameObject _mainCamera = null;
    [SerializeField] private GameObject[] _path;

    private int currIndex = 0;

    private void Start()
    {
        if (_playerRef == null)
            _playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();


        if (_mainCamera == null)
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        _mainCamera.GetComponent<CameraFollow>().enabled = false;
        _playerRef.gameIsPausedOrPlayerDead = true;
    }

    private void FixedUpdate()
    {
        
    }

}

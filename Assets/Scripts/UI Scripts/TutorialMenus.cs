using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenus : MonoBehaviour
{
    [SerializeField] private GameObject _movementTutorial = null;
    [SerializeField] private GameObject _combatTutorial = null;
    [SerializeField] private GameObject _spiritLinkTutorial = null;
    [SerializeField] private GameObject _wallJumpTutorial = null;

    private void Start()
    {
        if (_movementTutorial == null)
            Debug.LogError("Movement Tutorial is not assigned!");
        else
            _movementTutorial.SetActive(false);

        if (_combatTutorial == null)
            Debug.LogError("Combat Tutorial is not assigned!");
        else
            _combatTutorial.SetActive(false);

        if (_spiritLinkTutorial == null)
            Debug.LogError("Spirt Link Tutorial is not assigned!");
        else
            _spiritLinkTutorial.SetActive(false);

        if (_wallJumpTutorial == null)
            Debug.LogError("Wall Jump Tutorial is not assigned!");
        else
            _wallJumpTutorial.SetActive(false);
    }

    public void openMovementTutorial()
    {
        _movementTutorial.SetActive(true);
        _combatTutorial.SetActive(false);
        _spiritLinkTutorial.SetActive(false);
        _wallJumpTutorial.SetActive(false);
    }

    public void openComabtTutorial()
    {
        _movementTutorial.SetActive(false);
        _combatTutorial.SetActive(true);
        _spiritLinkTutorial.SetActive(false);
        _wallJumpTutorial.SetActive(false);
    }

    public void openSpiritLinkTutorial()
    {
        _movementTutorial.SetActive(false);
        _combatTutorial.SetActive(false);
        _spiritLinkTutorial.SetActive(true);
        _wallJumpTutorial.SetActive(false);
    }

    public void openWallJumpTutorial()
    {
        _movementTutorial.SetActive(false);
        _combatTutorial.SetActive(false);
        _spiritLinkTutorial.SetActive(false);
        _wallJumpTutorial.SetActive(true);
    }

    public void closeAllTutorials()
    {
        _movementTutorial.SetActive(false);
        _combatTutorial.SetActive(false);
        _spiritLinkTutorial.SetActive(false);
        _wallJumpTutorial.SetActive(false);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ItemReactivateBulk : MonoBehaviour
{
    [SerializeField] GameObject[] _reactivateObjects;
    [SerializeField] GameObject[] _doors;
    [SerializeField] GameObject _player;
    [SerializeField] int _playerHealth;
    public List<bool> collected = new List<bool>();
    private List<bool> Opened = new List<bool>();
    private int collLength = 0;
    private int openLength = 0;
    private int length = 0;
    private bool activating = false;
    private CollectableManager collMan;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        collMan = GetComponent<CollectableManager>();
    }

    private void FixedUpdate()
    {
        if (_player.GetComponent<PlayerHealth>().health == 0)
        {
            if (activating == false)
            {
                activating = true;
                Invoke("Activate", 2.2f);
            }
        }

        if(collLength < _reactivateObjects.Length)
        {
            collected.Add(false);
            collLength++;
        }

        if (openLength < _doors.Length)
        {
            Opened.Add(false);
            openLength++;
        }
    }

    private void Activate()
    {
        foreach (GameObject item in _reactivateObjects)
        {
            int index = collected.IndexOf(collected[length]);
            if (item.activeInHierarchy == false)
            {
                if (collected[index] == false)
                {
                    item.SetActive(true);
                }
            }
            length++;
        }
        length = 0;

        foreach (GameObject item in _doors)
        {
            if (item.GetComponent<OpenDoor>().doorOpened == true)
            {
                if (Opened[length] == false)
                {
                    item.GetComponent<OpenDoor>().CloseDoor();
                }
            }
            length++;
        }
        length = 0;

        activating = false;
    }

    public void SaveCollectables()
    {
        foreach (GameObject item in _reactivateObjects)
        {
            //int index = collected.IndexOf(collected[length]);
            if (item.activeInHierarchy == false)
            {
                collected[length] = true;
            }
            length++;
        }
        length = 0;
    }

    public void SaveDoors()
    {
        foreach (GameObject item in _doors)
        {
            if (item.GetComponent<OpenDoor>().doorOpened == true)
            {
                Opened[length] = true;
            }
            length++;
        }
        length = 0;
    }
}

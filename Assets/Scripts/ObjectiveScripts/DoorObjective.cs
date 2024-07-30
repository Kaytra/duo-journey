using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjective : MonoBehaviour
{
    public int doorcount;
    public int doorsOpened;
    public GameObject obj1, obj2, obj3, obj4; /*UI*/
    public GameObject open1, open2, open3, open4; /*UI*/
    public GameObject[] doors;
    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Hinge");
        doorcount = doors.Length;
        doorsOpened = 0;
        open1.SetActive(false);
        open2.SetActive(false);
        open3.SetActive(false);
        open4.SetActive(false);
        if (doorcount == 1)
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
        }
        if (doorcount == 2)
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(false);
            obj4.SetActive(false);
        }
        if (doorcount == 3)
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(true);
            obj4.SetActive(false);
        }
        if (doorcount == 4)
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(true);
            obj4.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doorsOpened == 0)
        {
            open1.SetActive(false);
            open2.SetActive(false);
            open3.SetActive(false);
            open4.SetActive(false);
        }
        if(doorsOpened == 1)
        {
            open1.SetActive(true);
            open2.SetActive(false);
            open3.SetActive(false);
            open4.SetActive(false);
        }
        if (doorsOpened == 2)
        {
            open1.SetActive(true);
            open2.SetActive(true);
            open3.SetActive(false);
            open4.SetActive(false);
        }
        if (doorsOpened == 3)
        {
            open1.SetActive(true);
            open2.SetActive(true);
            open3.SetActive(true);
            open4.SetActive(false);
        }
        if (doorsOpened == 4)
        {
            open1.SetActive(true);
            open2.SetActive(true);
            open3.SetActive(true);
            open4.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        doorsOpened += 1;
    }

    public void DoorClosed()
    {
        doorsOpened -= 1;
    }
}

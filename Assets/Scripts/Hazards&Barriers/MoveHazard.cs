using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHazard : MonoBehaviour
{
    [SerializeField] NavPoints[] myPoints = null;
    [SerializeField] float movespeed = 10;
    private string Currpoint;
    private int myIndex = 0;
    private Vector2 travelPosition;
    private Transform mytrans;
    private Vector2 trans;

    private void Start()
    {
        mytrans = GetComponent<Transform>();
        travelPosition = myPoints[myIndex].transform.position;
        Currpoint = myPoints[myIndex].gameObject.name;
    }

    private void Update()
    {
        mytrans = GetComponent<Transform>();

        float dis = Vector2.Distance(mytrans.position, travelPosition);
        float moveDis = Mathf.Clamp(movespeed * Time.deltaTime, 0, dis);

        trans = mytrans.position;

        Vector2 move = (travelPosition - trans).normalized * moveDis;
        mytrans.Translate(move, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NavPoints>() != null && other.gameObject.name == Currpoint)
        {
            ++myIndex;
            if (myIndex >= myPoints.Length)
            {
                myIndex = 0;
            }
            travelPosition = myPoints[myIndex].transform.position;
            Currpoint = myPoints[myIndex].gameObject.name;
        }
    }
}

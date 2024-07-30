using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    public GameObject[] NavPoints;
    int current = 0;
    public float speed;
    float NavRadius = 1;
    private GameObject Player;
    private bool attached = false;

    private void Update()
    {
        if (Vector3.Distance(NavPoints[current].transform.position, transform.position) < NavRadius)
        {
            current = Random.Range(0, NavPoints.Length);
            if (current >= NavPoints.Length)
            {
                current = 0;
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, NavPoints[current].transform.position, Time.deltaTime * speed);
        /*float dis = Vector2.Distance(transform.position, NavPoints[current].transform.position);
        float moveDis = Mathf.Clamp(speed * Time.deltaTime, 0, dis);

        Vector2 move = (NavPoints[current].transform.position - transform.position).normalized * moveDis;
        transform.Translate(move, Space.World);
        if (attached == true)
        {
            Player.GetComponent<CharacterController>().Move(new Vector3(move.x, 0, 0));
        }*/
        //transform.position = Vector2.Lerp(transform.position, NavPoints[current].transform.position, speed/2.5f * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        float dis = Vector2.Distance(transform.position, NavPoints[current].transform.position);
        float moveDis = Mathf.Clamp(speed * Time.deltaTime, 0, dis);

        Vector2 move = (NavPoints[current].transform.position - transform.position).normalized * moveDis;
        transform.Translate(move, Space.World);
        if (attached == true)
        {
            Player.GetComponent<CharacterController>().Move(new Vector3(move.x, move.y, 0));
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            attached = true;
            /*float dis = Vector2.Distance(other.gameObject.transform.position, NavPoints[current].transform.position);
            float moveDis = Mathf.Clamp(speed * Time.deltaTime, 0, dis);

            Vector2 move = (NavPoints[current].transform.position - other.gameObject.transform.position).normalized * moveDis;
            other.gameObject.transform.Translate(move, Space.World);
            //other.gameObject.transform.position = Vector2.Lerp(other.gameObject.transform.position, NavPoints[current].transform.position, speed / 2f * Time.deltaTime);
        }
    }*/

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            attached = false;
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            attached = true;
        }
        else
        {
            attached = false;
        }
    }
}

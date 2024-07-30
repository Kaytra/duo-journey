using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetoward : MonoBehaviour
{
    public GameObject [] player;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {


            if (Vector3.Distance(player[current].transform.position, transform.position) < WPradius)
            {
                current++;
                if (current >= player.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, player[current].transform.position, Time.deltaTime * speed);
        }
    }

    // Update is called once per frame
   // void OnTriggerEnter(Collider col)
    //{
        //if (col.CompareTag("Player"))
        //{
            //Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            //transform.LookAt(player.transform);

            //transform.position += transform.forward * 1f * Time.deltaTime;
        //}
    //}
}

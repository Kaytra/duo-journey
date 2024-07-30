using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerattachPanel : MonoBehaviour
{
    public GameObject Player;


    //private void OnTriggerStay(Collider other)
    //{
        //if (other.gameObject.tag == "Player")
        //{
          //  Player.transform.parent = transform;
       // }
        //else if (other.gameObject.tag == "")
        //{
            //Player.transform.parent = null;
        //}
        

   //}
  void  OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;
            //other.gameObject.transform.SetParent(gameObject.transform);
        }
   }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
            //other.gameObject.transform.SetParent(.gameObject.transform);
        }
    }
}

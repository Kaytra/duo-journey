using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDoorText : MonoBehaviour
{
    public GameObject Uiobject;
    // Start is called before the first frame update
    void Start()
    {
        Uiobject.SetActive(false);
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Uiobject.SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

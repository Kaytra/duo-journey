using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroyPanel : MonoBehaviour
{
    public GameObject Panel;
    public AudioSource BreakSound;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(Panel);
            BreakSound.Play();
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] GameObject destroy = null;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(destroy, gameObject.transform.position, gameObject.transform.rotation);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HurtPlayer();
        }
        Destroy(gameObject);
    }
}

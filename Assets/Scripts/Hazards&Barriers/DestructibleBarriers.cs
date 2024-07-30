using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBarriers : MonoBehaviour
{
    //[SerializeField] GameObject _player = null;
    /*[SerializeField] GameObject _Body = null;
    [SerializeField] GameObject explosion = null;
    [SerializeField] AudioClip _destroy = null;
    [SerializeField] AudioClip _damaged = null;
    [SerializeField] Slider barSlider = null;*/
    //[SerializeField] float KbStrength = 2;
    //[SerializeField] int _damage = 1;
    //private AudioSource _audsou;
    //private Transform myTrans;
    /*public int currHealth = 1;
    public int maxHealth = 3;/**/

    private void Start()
    {
        /*currHealth = maxHealth;
        barSlider.maxValue = maxHealth;
        barSlider.value = currHealth;*/
        //myTrans = GetComponentInParent<Transform>();
        //_audsou = GetComponent<AudioSource>();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == _player)
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= _damage;
            Vector2 direc = (_player.GetComponentInParent<Transform>().position - myTrans.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direc * KbStrength, ForceMode.Impulse);
        }
    }*/

    /*public void Damage(int damage)
    {
        _audsou.clip = _damaged;
        _audsou.Play();
        currHealth -= damage;
        barSlider.value = currHealth;

        if(currHealth <= 0)
        {
            _audsou.clip = _destroy;
            _audsou.Play();
            Instantiate(explosion, myTrans.position, myTrans.rotation);
            Destroy(_Body);
            //this.gameObject.SetActive(false);
        }
    }*/
}

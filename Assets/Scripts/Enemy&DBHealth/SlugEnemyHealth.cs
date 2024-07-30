using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlugEnemyHealth : MonoBehaviour
{

    [SerializeField] AudioSource _audsou = null;
    [SerializeField] AudioClip _damaged = null;
    [SerializeField] GameObject Death = null;
    [SerializeField] GameObject _Body = null;
    [SerializeField] Slider barSlider = null;
    [SerializeField] GameObject barcanvas = null;
    private Transform myTrans;
    public int currHealth = 1;
    public int maxHealth = 2;

    private void Start()
    {
        myTrans = _Body.transform;
        currHealth = maxHealth;
        barSlider.maxValue = maxHealth;
        barSlider.value = currHealth;
    }

    public void Damage(int damage)
    {
        _audsou.clip = _damaged;
        _audsou.Play();
        currHealth -= damage;
        barSlider.value = currHealth;
        barcanvas.SetActive(true);

        if (currHealth <= 0)
        {
           
            Instantiate(Death, myTrans.position, myTrans.rotation);
            Destroy(_Body);
        }
    }


    public void KillEnemy()
    {
        currHealth = 0;
        Instantiate(Death, myTrans.position, myTrans.rotation);
        Destroy(_Body);
    }
}

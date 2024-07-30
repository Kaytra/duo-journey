using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatT : MonoBehaviour
{
    public GameObject combatTxt, healthTxt, enemy, hOrb, tutorialPanel, tutorialManager, HPholder;
    public bool enemydown, healthCollected, completed;
    // Start is called before the first frame update
    void Start()
    {
        combatTxt.SetActive(true);
        healthTxt.SetActive(false);
        enemydown = false;
        healthCollected = false;
        completed = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        HPholder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.activeInHierarchy == false)
        {
            enemydown = true;
            HPholder.SetActive(true);
        }

        if (hOrb == null)
        {
            healthCollected = true;
        }

        if (healthCollected == false && enemydown == true)
        {
            combatTxt.SetActive(false);
            healthTxt.SetActive(true);
        }

        if(enemydown == true && healthCollected == true)
        {
            completed = true;
        }
        else
        {
            completed = false;
        }
    }



    private void Completed()
    {
        tutorialPanel.SetActive(false);
        tutorialManager.GetComponent<TutorialManager>().finished = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (completed == true)
            {
                Completed();
            }
        }
    }
}

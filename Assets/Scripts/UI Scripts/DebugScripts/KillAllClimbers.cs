using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllClimbers : MonoBehaviour
{
    private GameObject[] allClimberEnemies;

    public void killAllClimber()
    {
        allClimberEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in allClimberEnemies)
            if (go.GetComponent<SlugEnemyWaypoint>() != null)
                go.GetComponentInChildren<Health>().KillEnemy();
    }
}

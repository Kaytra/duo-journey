using UnityEngine;

public class KillAllHoppers : MonoBehaviour
{
    private GameObject[] allHoppingEnemies;

    public void killAllHoppers()
    {
        allHoppingEnemies = GameObject.FindGameObjectsWithTag("HoppingEnemy");
        foreach (GameObject go in allHoppingEnemies)
            go.GetComponentInChildren<Health>().KillEnemy();
    }
}

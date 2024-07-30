using UnityEngine;

public class KillAllChargers : MonoBehaviour
{
    private GameObject[] allChargingEnemies;

    public void killAllChargers()
    {
        allChargingEnemies = GameObject.FindGameObjectsWithTag("ChargingEnemy");
        foreach (GameObject go in allChargingEnemies)
            go.GetComponentInChildren<Health>().KillEnemy();
    }
}

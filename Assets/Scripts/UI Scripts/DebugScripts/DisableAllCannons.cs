using UnityEngine;

public class DisableAllCannons : MonoBehaviour
{
    private GameObject[] allCannons;

    public void disableAllCannons()
    {
        allCannons = GameObject.FindGameObjectsWithTag("Cannon");
        foreach (GameObject go in allCannons)
            go.GetComponentInChildren<RangedHazard>().toggleFireing();
    }
}

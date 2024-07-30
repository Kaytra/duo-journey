using System.Dynamic;
using UnityEngine;

public class ForceBackCheckpoint : MonoBehaviour
{
    private GameObject playerRef;
    private GameObject playerParent;

    private CheckpointScript checkRef;


    public void forceBackToCheckpoint()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        playerParent = playerRef.transform.parent.gameObject;

        checkRef = playerParent.GetComponentInChildren<CheckpointScript>();

        checkRef.teleportPlayerToCheckpoint();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBar : MonoBehaviour
{
    public float maxSpirit;
    [SerializeField] public float currentSpirit;
    [SerializeField] public float holdcount;
    public GameObject checkpoint;
    public GameObject orbUI;
    public GameObject holdUI;
    void Start()
    {
        maxSpirit = checkpoint.GetComponent<CheckpointScript>().maxSpirit;

    }

    // Update is called once per frame
    void Update()
    {
        holdcount = checkpoint.GetComponent<CheckpointScript>().holdCount;
        currentSpirit = checkpoint.GetComponent<CheckpointScript>().curSpirit;
        holdUI.GetComponent<Image>().fillAmount = holdcount;
        orbUI.GetComponent<Image>().fillAmount = currentSpirit / 100;

    }
}

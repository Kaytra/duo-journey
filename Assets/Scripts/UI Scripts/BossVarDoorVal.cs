using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossVarDoorVal : MonoBehaviour
{
    private GameObject collectableManager;
    public GameObject hinge, equalScreenFrame, underScreenFrame, equalEffect, underEffect, valueCanvas;
    public TextMeshProUGUI reqValueTxt;
    private int value;
    // Start is called before the first frame update
    void Start()
    {
        collectableManager = GameObject.FindGameObjectWithTag("CollectableManager");
        value = hinge.gameObject.GetComponent<OpenDoor>()._requiredCollectableCount;
        reqValueTxt.text = "" + value;
        equalEffect.SetActive(false);
        underEffect.SetActive(true);
        equalScreenFrame.SetActive(false);
        underScreenFrame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (value <= collectableManager.GetComponent<CollectableManager>().getScore())
        {
            equalEffect.SetActive(true);
            underEffect.SetActive(false);
            equalScreenFrame.SetActive(true);
            underScreenFrame.SetActive(false);
        }
        if (hinge.gameObject.GetComponent<OpenDoor>().doorOpened == true)
        {
            equalEffect.SetActive(false);
            underEffect.SetActive(false);
            equalScreenFrame.SetActive(false);
            underScreenFrame.SetActive(true);
            valueCanvas.SetActive(false);
        }
    }
}

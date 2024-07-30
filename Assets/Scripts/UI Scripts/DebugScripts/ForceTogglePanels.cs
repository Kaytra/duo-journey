using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTogglePanels : MonoBehaviour
{
    [SerializeField] private GameObject[] _movingPanelButtons;

    public void advancePanels()
    {
        foreach (GameObject button in _movingPanelButtons)
        {
            //Debug.LogWarning(panel.name + " is tracked by debug");
            if (button.GetComponentInChildren<PanelControl1>() != null)
            {
                PanelControl1 scriptRef = button.GetComponentInChildren<PanelControl1>();

                if (scriptRef.ispressed == false)
                    scriptRef.togglePanelOn();
                else if (scriptRef.ispressed == true)
                    scriptRef.togglePanelOff();
            }

            if (button.GetComponentInChildren<PanelControl2>() != null)
            {
                PanelControl2 scriptRef = button.GetComponentInChildren<PanelControl2>();

                if (scriptRef.ispressed == false)
                    scriptRef.togglePanelOn();
                else if (scriptRef.ispressed == true)
                    scriptRef.togglePanelOff();
            }
        }
    }
}

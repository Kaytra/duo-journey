using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObjective : MonoBehaviour
{
    public int bosshealth;
    public GameObject Boss;
    public GameObject objCompleted;
    // Start is called before the first frame update
    void Start()
    {
        objCompleted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bosshealth = Boss.GetComponent<BossHealth>().getCurrHealth();
        if(bosshealth <= 0)
        {
            objCompleted.SetActive(true);
        }
    }
}

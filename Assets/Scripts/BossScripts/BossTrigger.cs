using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private BossAI _bossAIRef = null;
    [SerializeField] private GameObject _playerRef = null;
    private bool playerNear = false;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (!_bossAIRef.checkBossFightActive())
        {
            Debug.DrawRay(this.transform.position, _playerRef.transform.position - transform.position, Color.green);
            if (Physics.Raycast(transform.position, _playerRef.transform.position - transform.position, out hit, 10f))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    _bossAIRef.beginBossFight();
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}

using UnityEngine;

public class ChargerHit : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Charger _charger;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == _charger._player)
        {
            _charger._player.GetComponent<CharacterMovement>().Damaged();
            health.Damage(health.currHealth);
        }

        if (collision.gameObject.tag == "Wall")
        {
            health.Damage(health.currHealth);
        }
    }
}

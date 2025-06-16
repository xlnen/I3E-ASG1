using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] int trapDamage = 30;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            if (player != null)
            {
                player.ModifyHealth(-trapDamage);
            }
        }
    }
}

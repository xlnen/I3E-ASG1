
/*
 * Author: Mio
 * Date: 2025-06-15
 * Description:  Handles damage to the player when they enter the trap area
 */
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

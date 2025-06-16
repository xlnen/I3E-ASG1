using UnityEngine;

public class GasleakBehaviour : MonoBehaviour
{
    [SerializeField] int damageAmount = 5;
    [SerializeField] float damageInterval = 1f;

    PlayerBehaviour playerInGas;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInGas = other.GetComponent<PlayerBehaviour>();
            InvokeRepeating(nameof(DamagePlayer), 0f, damageInterval);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke(nameof(DamagePlayer));
            playerInGas = null;
        }
    }

    void DamagePlayer()
    {
        if (playerInGas != null)
        {
            playerInGas.ModifyHealth(-damageAmount);
            Debug.Log("Player Health: " + playerInGas.currentHealth);
        }
    }
}

using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    GameObject coinPrefab; 

    [SerializeField]
    int numberOfCoins = 1; 

    [SerializeField]
    float spawnRadius = 1f; 

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Projectile"))
        {
            SpawnCoins();

            Destroy(collision.gameObject); 
            Destroy(gameObject);           
        }
    }

    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            
            Vector3 offset = Random.insideUnitSphere * spawnRadius;
            offset.y = Mathf.Abs(offset.y); 

            Vector3 spawnPosition = transform.position + offset;

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

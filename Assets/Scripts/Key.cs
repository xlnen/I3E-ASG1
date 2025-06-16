
/*
 * Author: Mio
 * Date: 2025-06-15
 * Description: Handles key collectible behavior including raycasting and collecting the key to unlock door
 */
using UnityEngine;

public class Key : MonoBehaviour
{
    MeshRenderer myMeshRenderer;

    [SerializeField]
    Material highlightMat;
    Material originalMat;

    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        originalMat = myMeshRenderer.material;
    }

    public void Highlight()
    {
        myMeshRenderer.material = highlightMat;
    }

    public void Unhighlight()
    {
        myMeshRenderer.material = originalMat;
    }

    // Method to collect the key
    // This method will be called when the player interacts with the key
    // It takes a PlayerBehaviour object as a parameter
    // This allows the key to trigger the player's PickupKey method
    // The method is public so it can be accessed from other scripts
    public void Collect(PlayerBehaviour player)
    {
        Debug.Log("Key collected!");

        // Call the PickupKey method on the player to set hasKey to true
        player.PickupKey();

        Destroy(gameObject); // Destroy the key object
    }
}

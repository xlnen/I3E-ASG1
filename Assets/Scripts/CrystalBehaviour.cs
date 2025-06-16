
/*
 * Author: Mio
 * Date: 2025-06-15
 * Description: Handles crystal collectible behaviour including raycasting when near,
 *              and adding score when obj is collected
 */
using UnityEngine;

public class CrystalBehaviour : MonoBehaviour
{
    // Coin value that will be added to the player's score


    MeshRenderer myMeshRenderer;
    [SerializeField]
    int crystalValue = 1;

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



    // Method to collect the coin
    // This method will be called when the player interacts with the coin
    // It takes a PlayerBehaviour object as a parameter
    // This allows the coin to modify the player's score
    // The method is public so it can be accessed from other scripts
    public void Collect(PlayerBehaviour player)
    {
        // Logic for collecting the coin
        Debug.Log("Crystal collected!");

        // Add the coin value to the player's score
        // This is done by calling the ModifyScore method on the player object
        // The coinValue is passed as an argument to the method
        // This allows the player to gain points when they collect the coin
        player.ModifyScore(crystalValue);

        Destroy(gameObject); // Destroy the coin object
    }
}



using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Player's maximum health
    int maxHealth = 100;
    // Player's current health
    int currentHealth = 100;
    // Player's current score
    int currentScore = 0;
    // Flag to check if the player can interact with objects
    bool canInteract = false;
    // Stores the current coin object the player has detected
    CrystalBehaviour currentCrystal = null;
    DoorBehaviour currentDoor = null;

    bool doorClosed = true;


    [SerializeField]
    GameObject Projectile;

//    [SerializeField]
//    Transform spawnPoint;

    [SerializeField]
    float fireStrength = 0f;

    [SerializeField]
    float interactionDistance = 5f;

    //WEEK 6
//    void OnFire()
//    {
//        GameObject newProjectile = Instantiate(Projectile, spawnPoint.position, spawnPoint.rotation);

//        Vector3 fireForce = spawnPoint.forward * fireStrength;

//        newProjectile.GetComponent<Rigidbody>().AddForce(fireForce);
//    }




    //WEEK 4
    // The Interact callback for the Interact Input Action
    // This method is called when the player presses the interact button
    void OnInteract()
    {  
                {
            Debug.Log("Interacting with object");

        }
        // Check if the player can interact with objects
        if (canInteract)
        {

            // Check if the player has detected a obj or a door
            if (currentCrystal != null)
            {
                Debug.Log("Interacting with coin");
                // Call the Collect method on the  object
                // Pass the player object as an argument
                currentCrystal.Collect(this);
            }
            else if (currentDoor != null) //WEEK 5
            {
                Debug.Log("Interacting with door");

                if (doorClosed == true)
                {
                    currentDoor.Open();       // Opens the door
                    Debug.Log("Door open!");
                    doorClosed = false;       // Updates flag
                }
                else
                {
                    currentDoor.Close();      // Closes the door
                    Debug.Log("Door closed!");
                    doorClosed = true;        // Updates flag
                }
            }
        }
    }






    //WEEK 3

    // Method to modify the player's score
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current score
    // The method is public so it can be accessed from other scripts
    public void ModifyScore(int amt)
    {
        // Increase currentScore by the amount passed as an argument
        currentScore += amt;
    }



    //WEEK 3

    // Method to modify the player's health
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current health
    // The method is public so it can be accessed from other scripts
    public void ModifyHealth(int amount)
    {
        // Check if the current health is less than the maximum health
        // If it is, increase the current health by the amount passed as an argument
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
            // Check if the current health exceeds the maximum health
            // If it does, set the current health to the maximum health
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }




    /* WEEK 3
        // Collision Callback for when the player collides with another object
        void OnCollisionStay(Collision collision)
        {
            // Check if the player collides with an object tagged as "HealingArea"
            // If it does, call the RecoverHealth method on the object
            // Pass the player object as an argument
            // This allows the player to recover health when in a healing area
            if (collision.gameObject.CompareTag("HealingArea"))
            {
                collision.gameObject.GetComponent<RecoveryBehaviour>().RecoverHealth(this);
            }
        }
        */


    //WEEK 4
    // Trigger Callback for when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // Check if the player detects a trigger collider tagged as "Collectible" or "Door"
        if (other.CompareTag("Collectible"))
        {
            // Set the canInteract flag to true
            // Get the CoinBehaviour component from the detected object
            canInteract = true;
            currentCrystal = other.GetComponent<CrystalBehaviour>();
        }
        else if (other.CompareTag("Door"))
        {
            canInteract = true;
            currentDoor = other.GetComponent<DoorBehaviour>();
        }
    }

    // Trigger Callback for when the player exits a trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the player has a detected coin or door
        if (currentCrystal != null)
        {
            // If the object that exited the trigger is the same as the current coin
            if (other.gameObject == currentCrystal.gameObject)
            {
                // Set the canInteract flag to false
                // Set the current coin to null
                // This prevents the player from interacting with the coin
                canInteract = false;
                currentCrystal = null;
            }
        }
    }

    void Update()
    {
//        RaycastHit hitInfo;
//        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * interactionDistance, Color.red);
//        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hitInfo, interactionDistance))
//        {
            //Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);
//            if (hitInfo.collider.gameObject.CompareTag("Collectible"))
//            {
//                if (currentCoin != null)
//                {
//                    currentCoin.Unhighlight();
//                }

//                canInteract = true;
//                currentCoin = hitInfo.collider.gameObject.GetComponent<CoinBehaviour>();
//                currentCoin.Highlight();


            }
//        }

//        else if (currentCoin != null)
//        {
//            currentCoin.Unhighlight();
//            currentCoin = null;
//        }
//    }


}


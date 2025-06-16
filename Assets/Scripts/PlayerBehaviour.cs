
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Player's maximum health
    int maxHealth = 100;
    // Player's current health
    public int currentHealth = 100;    // Player's current score

    int currentScore = 0;
    // check if the player can interact with objects
    bool canInteract = false;
    // Stores the current coin object the player has detected
    bool hasKey = false;
    CrystalBehaviour currentCrystal = null;
    DoorBehaviour currentDoor = null;
    Key currentKey = null;

    bool doorClosed = true;

    [SerializeField]
    UnityEngine.UI.Text scoreText;
    [SerializeField] UnityEngine.UI.Text healthText;


    [SerializeField] UnityEngine.UI.Text collectiblesLeftText;
    [SerializeField] int totalCollectibles = 5;

    [SerializeField]
    GameObject Projectile;

    [SerializeField] UnityEngine.UI.Text congratsText;


    [SerializeField]
    float fireStrength = 0f;

    [SerializeField]
    float interactionDistance = 5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Save initial spawn position
    }

    //WEEK 4
    // The Interact callback for the Interact Input Action
    // This method is called when the player presses the interact button
    // The Interact callback for the Interact Input Action
    // This method is called when the player presses the interact button
    void OnInteract()
    {
        Debug.Log("Interacting with object");
        // Check if the player can interact with objects
        if (canInteract)
        {
            // Check if the player has detected an obj or a door
            if (currentCrystal != null)
            {
                Debug.Log("Interacting with coin");
                // Call the Collect method on the object
                // Pass the player object as an argument
                currentCrystal.Collect(this);
            }
            else if (currentKey != null) // Interact with the key
            {
                Debug.Log("Interacting with key");
                // Call the Collect method on the key
                currentKey.Collect(this);
            }
            else if (currentDoor != null) // WEEK 5
            {
                Debug.Log("Interacting with door");

                if (currentDoor.isLocked)
                {
                    if (hasKey)
                    {
                        currentDoor.Unlock();
                        Debug.Log("Door unlocked!");
                    }
                    else
                    {
                        Debug.Log("Door is locked. Key required.");
                        return;
                    }
                }

                if (doorClosed == true)
                {
                    currentDoor.Open();       // Opens the door
                    Debug.Log("Door open!");
                    doorClosed = false;
                }
                else
                {
                    currentDoor.Close();      // Closes the door
                    Debug.Log("Door closed!");
                    doorClosed = true;
                }
            }
        }
    }
    // Method to allow player to pick up a key
    public void PickupKey()
    {
        hasKey = true;
        Debug.Log("Player picked up the key!");
    }

    void Respawn()
    {
        // Reset health to max
        currentHealth = maxHealth;
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;

        transform.position = startPosition; // Move player back to starting position

        Debug.Log("Player respawned.");
    }
    //WEEK 3

    // Method to modify the player's score
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current score
    // The method is public so it can be accessed from other scripts
    public void ModifyScore(int amt)
    {
        currentScore += amt;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;

        }

        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }

        // Update remaining collectibles UI
        collectiblesLeftText.text = "Collectibles Left: " + (totalCollectibles - currentScore);

        if (currentScore >= totalCollectibles)
        {
            congratsText.enabled = true; // Show Congratulations UI
        }
    }


    //WEEK 3

    // Method to modify the player's health
    // This method takes an integer amount as a parameter
    // It adds the amount to the player's current health
    // The method is public so it can be accessed from other scripts
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth < 0) currentHealth = 0;


        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }

        if (currentHealth == 0)
        {
            Respawn();
        }

        Debug.Log("Current Health: " + currentHealth);
    }



    //WEEK 4
    // Trigger Callback for when the player enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.CompareTag("Collectible"))
        {
            canInteract = true;
            currentCrystal = other.GetComponent<CrystalBehaviour>();
        }
        else if (other.CompareTag("Door"))
        {
            canInteract = true;
            currentDoor = other.GetComponent<DoorBehaviour>();
        }
        else if (other.CompareTag("Key"))
        {
            canInteract = true;
            currentKey = other.GetComponent<Key>();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (currentCrystal != null && other.gameObject == currentCrystal.gameObject)
        {
            canInteract = false;
            currentCrystal = null;
        }
        else if (currentDoor != null && other.gameObject == currentDoor.gameObject)
        {
            canInteract = false;
            currentDoor.Close();
            doorClosed = true;
            currentDoor = null;
        }
        else if (currentKey != null && other.gameObject == currentKey.gameObject)
        {
            canInteract = false;
            currentKey = null;
        }

    }

    void Update()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * interactionDistance, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, interactionDistance))
        {
            Debug.Log("Raycast hit: " + hitInfo.collider.gameObject.name);

            if (hitInfo.collider.gameObject.CompareTag("Collectible"))
            {
                if (currentCrystal != null)
                {
                    currentCrystal.Unhighlight();
                }

                canInteract = true;
                currentCrystal = hitInfo.collider.gameObject.GetComponent<CrystalBehaviour>();
                currentCrystal.Highlight();

                if (currentKey != null)
                {
                    currentKey.Unhighlight();
                    currentKey = null;
                }
            }
            else if (hitInfo.collider.gameObject.CompareTag("Key"))
            {
                if (currentKey != null)
                {
                    currentKey.Unhighlight();
                }

                canInteract = true;
                currentKey = hitInfo.collider.gameObject.GetComponent<Key>();
                currentKey.Highlight();

                // Reset crystal highlight
                if (currentCrystal != null)
                {
                    currentCrystal.Unhighlight();
                    currentCrystal = null;
                }
            }
            else
            {
                // Not a collectible or key
                if (currentCrystal != null)
                {
                    currentCrystal.Unhighlight();
                    currentCrystal = null;
                }

                if (currentKey != null)
                {
                    currentKey.Unhighlight();
                    currentKey = null;
                }

                canInteract = false;
            }
        }
        else
        {
            // Nothing hit
            if (currentCrystal != null)
            {
                currentCrystal.Unhighlight();
                currentCrystal = null;
            }

            if (currentKey != null)
            {
                currentKey.Unhighlight();
                currentKey = null;
            }

            canInteract = false;
        }
    }
}



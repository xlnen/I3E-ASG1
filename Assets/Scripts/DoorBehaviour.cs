
/*
 * Author: Mio
 * Date: 2025-06-15
 * Description: Controls door behaviour, includes opening and closing and unlocking mechanic. door rotates 90 degree when opened and close after player walks away
 */
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    // Flag to check if the door is locked
    public bool isLocked = true;

    // Flag to track if the door is open
    bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Open()
    {
        // Only open if door is unlocked and currently closed
        if (!isLocked && !isOpen)
        {
            Vector3 doorRotation = transform.eulerAngles;
            doorRotation.y += 90f;
            transform.eulerAngles = doorRotation;
            isOpen = true;
        }
    }

    public void Close()
    {
        // Only close if door is open
        if (isOpen)
        {
            Vector3 doorRotation = transform.eulerAngles;
            doorRotation.y -= 90f;
            transform.eulerAngles = doorRotation;
            isOpen = false;
        }
    }

    // unlock the door
    public void Unlock()
    {
        isLocked = false;
    }
}

using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public void Open()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y += 90f;
        transform.eulerAngles = doorRotation;
    }

public void Close()
    {
        Vector3 doorRotation = transform.eulerAngles;
        doorRotation.y -= 90f;
        transform.eulerAngles = doorRotation;
    }


}

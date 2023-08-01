using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraPosition;
  
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform CameraPosition;
  
    void LateUpdate()
    {
        transform.position = CameraPosition.position;
    }
}

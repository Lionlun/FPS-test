using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform CameraPosition;
  
    void Update()
    {
        transform.position = CameraPosition.position;
    }
}

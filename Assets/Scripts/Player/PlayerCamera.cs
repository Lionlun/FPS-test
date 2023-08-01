using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform playerTransform;

    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RotateCamera();
	}

    void RotateCamera()
    {
	    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
	    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

		yRotation += mouseX;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90, 90);

		playerTransform.rotation = Quaternion.Euler(0, yRotation, 0);
		transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
	}
}


using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    private PlayerMotor motor;


    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
		//motor.Move(GetVelocity());
	}

	private Vector3 GetVelocity()
    {
		float xMovement = Input.GetAxisRaw("Horizontal");
		float zMovement = Input.GetAxisRaw("Vertical");

		Vector3 lateralMovement = transform.right * xMovement;
		Vector3 forwardMovement = transform.forward * zMovement;

		Vector3 velocity = (lateralMovement + forwardMovement).normalized * speed;

        return velocity;
	}
}

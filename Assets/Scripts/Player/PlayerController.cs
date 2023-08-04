
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] PlayerStanceHandler playerStanceHandler;

	CapsuleCollider playerCollider;

	[SerializeField] float speed = 5;
	float speedCoefficient = 1;
	float sprintBoost = 1;
    PlayerMotor motor;
    bool isSprinting;
	float distanceToGround;
	float jumpForce = 6f;


	private void OnEnable()
	{
		InputManager.OnSprintButtonPressed += Sprint;
		InputManager.OnSprintButtonReleased += StopSprint;
		InputManager.OnJumpButtonPressed += SendJump;
	}

	private void OnDisable()
	{
		InputManager.OnSprintButtonPressed -= Sprint;
		InputManager.OnSprintButtonReleased -= StopSprint;
		InputManager.OnJumpButtonPressed -= SendJump;
	}

	void Start()
    {
		playerCollider = GetComponent<CapsuleCollider>();
		distanceToGround = playerCollider.bounds.extents.y;
	    motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
		motor.GetMoveVelocity(GetVelocity());
		CheckGround();
	}

	private Vector3 GetVelocity()
    {
		float xMovement = Input.GetAxisRaw("Horizontal");
		float zMovement = Input.GetAxisRaw("Vertical");

		Vector3 lateralMovement = transform.right * xMovement;
		Vector3 forwardMovement = transform.forward * zMovement;

		Vector3 velocity = (lateralMovement + forwardMovement).normalized * speed;

		velocity *= GetSpeedCoefficient();
        
        return velocity;
	}

	private float GetSpeedCoefficient()
	{
		switch (playerStanceHandler.PlayerPosition)
		{
			case PlayerPosition.Stand:
				speedCoefficient = 1;
				break;
			case PlayerPosition.Crouch:
				speedCoefficient = 0.5f;
				break;
			case PlayerPosition.Lay:
				speedCoefficient = 0.2f;
				break;
		}

		var totalSpeedCoefficient = GetSprintBoost() * speedCoefficient;
		return totalSpeedCoefficient;
	}

	private float GetSprintBoost()
	{
		if (isSprinting)
		{
			sprintBoost = 1.3f;
		}
		else
		{
			sprintBoost = 1;
		}
		return sprintBoost;
	}

	private void Sprint()
	{
		isSprinting = true;
	}
	private void StopSprint()
	{
		isSprinting = false;
	}

	void SendJump()
	{
		motor.Jump(CheckGround(), jumpForce);
	}

	bool CheckGround()
	{
		Debug.Log(Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.4f));
		return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.4f);
	}
}

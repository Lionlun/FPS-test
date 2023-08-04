using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	#region CharacterMovementParameters
	[SerializeField] float jumpForce = 6f;
	[SerializeField] float speed = 5;
	[SerializeField] float sprintBoostValue = 1.3f;
	[SerializeField] float standSpeedCoefficient = 1;
	[SerializeField] float crouchSpeedCoefficient = 0.5f;
	[SerializeField] float laySpeedCoefficient = 0.2f;
	#endregion

	[SerializeField] PlayerStanceHandler playerStanceHandler;
	CapsuleCollider playerCollider;
	PlayerMotor motor;

	float speedCoefficient = 1;
	float noSprintBoost = 1;
	float sprintBoost;
    bool isSprinting;
	float distanceToGround;

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

		velocity *= CalculateSpeedCoefficient();
        
        return velocity;
	}

	private float CalculateSpeedCoefficient()
	{
		switch (playerStanceHandler.PlayerPosition)
		{
			case PlayerPosition.Stand:
				speedCoefficient = standSpeedCoefficient;
				break;
			case PlayerPosition.Crouch:
				speedCoefficient = crouchSpeedCoefficient;
				break;
			case PlayerPosition.Lay:
				speedCoefficient = laySpeedCoefficient;
				break;
		}

		var totalSpeedCoefficient = CalculateSprintBoost() * speedCoefficient;
		return totalSpeedCoefficient;
	}

	private float CalculateSprintBoost()
	{
		if (isSprinting)
		{
			sprintBoost = sprintBoostValue;
		}
		else
		{
			sprintBoost = noSprintBoost;
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
		return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.4f);
	}
}


using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	public PlayerPosition PlayerPosition;
	public PlayerStance StandStance;
	public PlayerStance CrouchStance;
	public PlayerStance LayStance;

	private CapsuleCollider playerCollider;

	private float PlayerPositionSmoothing = 0.1f;
	private float changeStanceSpeed = 6f;

	private float cameraHeight;
	private float cameraHeightVelocity = 2;

	[SerializeField] Transform cameraPosition;

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

		InputManager.OnCrouchButtonPressed += Crouch;
		InputManager.OnLayButtonPressed += Lay;

		InputManager.OnJumpButtonPressed += SendJump;
	}

	private void OnDisable()
	{
		InputManager.OnSprintButtonPressed -= Sprint;
		InputManager.OnSprintButtonReleased -= StopSprint;

		InputManager.OnCrouchButtonPressed -= Crouch;
		InputManager.OnLayButtonPressed -= Lay;

		InputManager.OnJumpButtonPressed -= SendJump;
	}

	void Start()
    {
		playerCollider = GetComponent<CapsuleCollider>();
		distanceToGround = playerCollider.bounds.extents.y;
		cameraHeight = cameraPosition.localPosition.y;
	    motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
		motor.GetMoveVelocity(GetVelocity());
		CheckGround();


	}

	private void LateUpdate()
	{
		GetStance();
	}

	private Vector3 GetVelocity()
    {
		float xMovement = Input.GetAxisRaw("Horizontal");
		float zMovement = Input.GetAxisRaw("Vertical");

		Vector3 lateralMovement = transform.right * xMovement;
		Vector3 forwardMovement = transform.forward * zMovement;

		Vector3 velocity = (lateralMovement + forwardMovement).normalized * speed;

		velocity *= GetSpeedcoefficient();
        
        return velocity;
	}

	private float GetSpeedcoefficient()
	{
		switch (PlayerPosition)
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

	private void GetStance()
	{
		var currentStance = StandStance;

		if (PlayerPosition == PlayerPosition.Crouch)
		{
			currentStance = CrouchStance;
		}
		else if(PlayerPosition == PlayerPosition.Lay)
		{
			currentStance = LayStance;
		}

		cameraHeight = Mathf.SmoothDamp(cameraPosition.localPosition.y, currentStance.CameraHeight, ref cameraHeightVelocity, PlayerPositionSmoothing);
		cameraPosition.localPosition = new Vector3(0, cameraHeight, 0);

		playerCollider.height = Mathf.SmoothDamp(playerCollider.height, currentStance.PlayerHeight, ref changeStanceSpeed, PlayerPositionSmoothing);
	}

	private void Crouch()
	{
		if (PlayerPosition != PlayerPosition.Crouch)
		{
			PlayerPosition = PlayerPosition.Crouch;
		}
		else
		{
			PlayerPosition = PlayerPosition.Stand;
		}
	}
	private void Lay()
	{
		if (PlayerPosition != PlayerPosition.Lay)
		{
			PlayerPosition = PlayerPosition.Lay;
		}
		else
		{
			PlayerPosition = PlayerPosition.Stand;
		}
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

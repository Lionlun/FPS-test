
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

	public PlayerPosition playerPosition;
	public float cameraStandHeight;
	public float cameraCrouchHeight;
	public float cameraLayHeight;
	public float playerPositionSmoothing = 1;

	private float cameraHeight;
	private float cameraHeightVelocity = 2;

	
	[SerializeField] Transform cameraPosition;

	[SerializeField] float speed = 5;
	float speedCoefficient = 1;
	float sprintBoost = 1;
    PlayerMotor motor;
    bool isSprinting;

	

	private void OnEnable()
	{
		InputManager.OnSprintButtonPressed += Sprint;
		InputManager.OnSprintButtonReleased += StopSprint;

		InputManager.OnCrouchButtonPressed += Crouch;
		InputManager.OnLayButtonPressed += Lay;
	}

	private void OnDisable()
	{
		InputManager.OnSprintButtonPressed -= Sprint;
		InputManager.OnSprintButtonReleased -= StopSprint;

		InputManager.OnCrouchButtonPressed -= Crouch;
		InputManager.OnLayButtonPressed -= Lay;
	}

	void Start()
    {
		cameraHeight = cameraPosition.localPosition.y;
	    motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
		motor.GetMoveVelocity(GetVelocity());
	
	}

	private void LateUpdate()
	{
		GetCameraHeight();
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
		switch (playerPosition)
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

	private void GetCameraHeight()
	{
		var positionHeight = cameraStandHeight;

		if (playerPosition == PlayerPosition.Crouch)
		{
			positionHeight = cameraCrouchHeight;
		}
		else if(playerPosition == PlayerPosition.Lay)
		{
			positionHeight = cameraLayHeight;
		}

		cameraHeight = Mathf.SmoothDamp(cameraPosition.localPosition.y, positionHeight, ref cameraHeightVelocity, playerPositionSmoothing);
		cameraPosition.localPosition = new Vector3(0, cameraHeight, 0);
	}

	private void Crouch()
	{
		if (playerPosition != PlayerPosition.Crouch)
		{
			playerPosition = PlayerPosition.Crouch;
		}
		else
		{
			playerPosition = PlayerPosition.Stand;
		}
	}
	private void Lay()
	{
		if (playerPosition != PlayerPosition.Lay)
		{
			playerPosition = PlayerPosition.Lay;
		}
		else
		{
			playerPosition = PlayerPosition.Stand;
		}
	}
}

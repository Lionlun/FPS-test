using UnityEngine;

public class PlayerStanceHandler : MonoBehaviour
{
	private CapsuleCollider playerCollider;

	public PlayerPosition PlayerPosition;
	public PlayerStance StandStance;
	public PlayerStance CrouchStance;
	public PlayerStance LayStance;

	private float PlayerPositionSmoothing = 0.1f;
	private float changeStanceSpeed = 6f;

	private float cameraHeight;
	private float cameraHeightVelocity = 2;

	[SerializeField] Transform cameraPosition;

	private void OnEnable()
	{
		InputManager.OnCrouchButtonPressed += Crouch;
		InputManager.OnLayButtonPressed += Lay;
	}
	private void OnDisable()
	{
		InputManager.OnCrouchButtonPressed -= Crouch;
		InputManager.OnLayButtonPressed -= Lay;
	}

	private void Start()
	{
		playerCollider = GetComponent<CapsuleCollider>();
		cameraHeight = cameraPosition.localPosition.y;
	}

	private void LateUpdate()
	{
		GetStance();
	}

	private void GetStance()
	{
		var currentStance = StandStance;

		if (PlayerPosition == PlayerPosition.Crouch)
		{
			currentStance = CrouchStance;
		}
		else if (PlayerPosition == PlayerPosition.Lay)
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
}

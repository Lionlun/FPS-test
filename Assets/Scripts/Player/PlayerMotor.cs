using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	[SerializeField] Camera cam;

    private Vector3 velocity = Vector3.zero;


	private float jumpForce = 3f;
	private bool isOnGround;
	[SerializeField] Transform groundPoint;
	[SerializeField] LayerMask ground;



	private Rigidbody rb;


	private void OnEnable()
	{
		InputManager.OnJumpButtonPressed += Jump;
	}
	private void OnDisable()
	{
		InputManager.OnJumpButtonPressed -= Jump;
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Move();
	}

	public void GetMoveVelocity (Vector3 velocity)
	{
		this.velocity = velocity;
	}

	private void Move()
	{
        if (velocity != Vector3.zero)
        {
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

	private void Jump()
	{
		if (isOnGround)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isOnGround = true;
		}
	}
}

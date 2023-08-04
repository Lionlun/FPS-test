using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	[SerializeField] Camera cam;
	[SerializeField] Transform groundPoint;
	[SerializeField] LayerMask ground;

	Vector3 velocity = Vector3.zero;

	Rigidbody rb;

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

	public void Jump(bool isGrounded, float jumpForce)
	{
		if (isGrounded)
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}
}

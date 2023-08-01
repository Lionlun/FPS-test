using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	[SerializeField] Camera cam;

    private Vector3 velocity = Vector3.zero;
	private Rigidbody rb;

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
}

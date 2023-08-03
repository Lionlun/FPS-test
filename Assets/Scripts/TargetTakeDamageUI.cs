using UnityEngine;

public class TargetTakeDamageUI : MonoBehaviour
{
	float speed = 5;
	private PlayerCamera cam;
	private void Start()
	{
		cam = FindObjectOfType<PlayerCamera>();
        Destroy(gameObject, 1);
	}
	void Update()
    {
        Move();
    }

	void LateUpdate()
	{
		transform.LookAt(transform.position + cam.transform.forward);
	}
	void Move()
    {
        transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }
}

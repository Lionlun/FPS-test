using TMPro;
using UnityEngine;

public class TargetTakeDamageUI : MonoBehaviour
{	
	float speed = 5;
	private PlayerCamera cam;
	TextMeshProUGUI damageText;
	PlayerWeapon playerWeapon;

	private void Start()
	{
		damageText = GetComponentInChildren<TextMeshProUGUI>();
		playerWeapon = FindObjectOfType<PlayerShooting>().Weapon;
		damageText.text = playerWeapon.Damage.ToString();
		damageText = GetComponentInChildren<TextMeshProUGUI>();
		cam = FindObjectOfType<PlayerCamera>();
        Destroy(gameObject, 1);
	}

	void Update()
    {
        Move();
    }

	private void LateUpdate()
	{
		LookAtPlayer();
	}
	private void Move()
    {
        transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }

	private void LookAtPlayer()
	{
		transform.LookAt(transform.position + cam.transform.forward);
	}
}

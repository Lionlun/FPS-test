using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    int currentHealth;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	private void Update()
	{
		if (currentHealth <= 0) 
		{
			Die();
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if (currentHealth < 0) 
		{
			currentHealth = 0;
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}

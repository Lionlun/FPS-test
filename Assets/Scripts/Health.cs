using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int MaxHealth = 10;
    public int CurrentHealth;

	private void Start()
	{
		CurrentHealth = MaxHealth;
	}

	private void Update()
	{
		if (CurrentHealth <= 0) 
		{
			Die();
		}
	}

	public void TakeDamage(int damage)
	{
		var objectHealth = GetComponent<IHealth>();

		if (objectHealth != null)
		{
			objectHealth.TakeDamage(damage);
		}
	
		CurrentHealth -= damage;

		if (CurrentHealth < 0)
		{
			CurrentHealth = 0;
		}
		
	}

	void Die()
	{
		var objectHealth = GetComponent<IHealth>();

		if (objectHealth != null)
		{
			objectHealth.Die();
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

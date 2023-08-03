using System.Threading.Tasks;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int MaxHealth = 10;
    public int CurrentHealth;
	private bool isDead;

	private void Start()
	{
		CurrentHealth = MaxHealth;
	}

	public void TakeDamage(int damage)
	{
		var objectHealth = GetComponent<IHealth>();

		if (objectHealth != null)
		{
			objectHealth.TakeDamage(damage);
		}
		else
		{
			CurrentHealth -= damage;
		}

		CurrentHealth -= damage;

		if (CurrentHealth <= 0)
		{
			Die();
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

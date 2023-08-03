using UnityEngine;

public class Target : MonoBehaviour, IHealth
{
    
    float speed = 10;
    private Vector3 startPosition;
    private TargetSpawner spawner;
    [SerializeField] private TargetTakeDamageUI targetTakeDamageUI;

	void Start()
    {
		spawner = FindObjectOfType<TargetSpawner>();
		startPosition = new Vector3(Random.Range(-4, 4), transform.position.y, transform.position.y);
	}

    void Update()
    {
		Move();
	}

    public void Die()
    {
        Debug.Log("Target Destroyed");
		spawner.SpawnTarget();
  
        Destroy(gameObject);
	}
    public void TakeDamage(int damage)
    {
		Instantiate(targetTakeDamageUI, transform.position, Quaternion.identity);
	}
    private void Move()
    { 
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time), 0, 0) * speed;
    }

}

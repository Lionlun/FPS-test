using System.Threading.Tasks;
using UnityEngine;

public class Target : MonoBehaviour, IHealth
{
    Vector3 offset = new Vector3(0, 0, -1);
    float speed = 10;
    private Vector3 startPosition;
    private TargetSpawner spawner;
    private TargetSound targetSound;
    [SerializeField] private TargetTakeDamageUI targetTakeDamageUI;
    [SerializeField] private ParticleSystem targetDestructionEffect;
	MeshRenderer meshRenderer;
  

	void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		targetSound = GetComponent<TargetSound>();
		spawner = FindObjectOfType<TargetSpawner>();
		startPosition = new Vector3(Random.Range(-4, 4), transform.position.y, transform.position.z);
	}

    void Update()
    {
		Move();
	}

    public async void Die()
    {
		targetSound.PlayShotSound();
		meshRenderer.enabled = false;
		var destroyEffect = Instantiate(targetDestructionEffect, transform.position, Quaternion.identity);
		destroyEffect.Play();
		await Task.Delay(1000);
		spawner.SpawnTarget();
		Destroy(gameObject);
	}
    public void TakeDamage(int damage)
    {
		Instantiate(targetTakeDamageUI, transform.position + offset, Quaternion.identity);
		targetSound.PlayShotSound();
	}
    private void Move()
    { 
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time), 0, 0) * speed;
    }
}

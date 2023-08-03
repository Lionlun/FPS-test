using System.Threading.Tasks;
using UnityEngine;

public class Target : MonoBehaviour, IHealth
{
	[SerializeField] private TargetTakeDamageUI targetTakeDamageUI;
	[SerializeField] private ParticleSystem targetDestructionEffect;

	private Vector3 offset = new Vector3(0, 0, -1);
    private float speed = 10;
    private Vector3 startPosition;
    private TargetSpawner spawner;
    private TargetSound targetSound;

	private MeshRenderer meshRenderer;
	private PlayerController playerController;
  

	private void Start()
	{
		playerController = FindObjectOfType<PlayerController>();
		meshRenderer = GetComponent<MeshRenderer>();
		targetSound = GetComponent<TargetSound>();
		spawner = FindObjectOfType<TargetSpawner>();
		startPosition = new Vector3(Random.Range(-4, 4), transform.position.y, transform.position.z);
	}

   private void Update()
    {
		Move();
	}

    public async void Die()
    {
		targetSound.PlayShotSound();
		meshRenderer.enabled = false;
		PlayDestroyEffect();
		await Task.Delay(1000);
		spawner.SpawnTarget();
		Destroy(gameObject);
	}

    public void TakeDamage(int damage)
    {
		ShowDamage();
		targetSound.PlayShotSound();
	}

    private void Move()
    { 
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time), 0, 0) * speed;
    }

	private void ShowDamage()
	{
		offset = (playerController.transform.position - transform.position).normalized;
		Instantiate(targetTakeDamageUI, transform.position + offset, Quaternion.identity);
	}

	private void PlayDestroyEffect()
	{
		var destroyEffect = Instantiate(targetDestructionEffect, transform.position, Quaternion.identity);
		destroyEffect.Play();
	}
}

using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] GameObject target;


	private void Start()
	{
		SpawnTarget();
	}
	public void SpawnTarget()
    {
		Instantiate(target, transform.position, target.transform.rotation);
	}
}

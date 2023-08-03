using System.Threading.Tasks;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject target;
	private int timeToSpawnTarget = 2000;

	private void Start()
	{
		SpawnTarget();
	}

	public async void SpawnTarget()
    {
		await Task.Delay(timeToSpawnTarget);
		if(this != null)
		{
			Instantiate(target, transform.position, target.transform.rotation);
		}
	}
}

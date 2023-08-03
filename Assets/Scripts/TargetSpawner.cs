using System.Threading.Tasks;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] GameObject target;

	private void Start()
	{
		SpawnTarget();
	}
	public async void SpawnTarget()
    {
		await Task.Delay(2000);
		if(this != null)
		{
			Instantiate(target, transform.position, target.transform.rotation);
		}
	}
}

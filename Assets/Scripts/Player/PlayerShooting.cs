using System.Threading.Tasks;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	private const string TARGET_TAG = "Target";

	[SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;
	[SerializeField] PistolAnimation pistolAnimation;


    public PlayerWeapon weapon;

	public ParticleSystem muzzleFlash;
	public ParticleSystem hitEffect;

	bool isReloading;
	int reloadTime = 1000;
	

	private void OnEnable()
	{
        InputManager.OnLMBPressed += Shoot;
	}
	private void OnDisable()
	{
		InputManager.OnLMBPressed -= Shoot;
	}

	void Shoot()
    {
        if (weapon.ammo <= 0)
        {
            Reload();
            return;
        }
        else
        {
			weapon.ammo--;
			muzzleFlash.Play();
			pistolAnimation.PlayShotAnimation();

			Debug.Log("Remaining Bullets " + weapon.ammo);
			

			RaycastHit hit;

			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.effectiveRange, layerMask))
			{
				if (hit.collider.tag == TARGET_TAG)
				{
					var targetHealth = hit.collider.gameObject.GetComponent<Health>();
					targetHealth.TakeDamage(10); //TO DO заменить число на урон от оружия
				}
				
				Debug.Log("We hit " + hit.collider.name);

				PlayHitEffect(hit.point, hit.normal);
			}
		}
		
    }

	private void PlayHitEffect(Vector3 point, Vector3 normal)
	{
		Instantiate(hitEffect, point, Quaternion.LookRotation(normal));
	}

	private async void Reload()
	{
		if (isReloading)
		{
			return;
		}
		else
		{
			isReloading = true;
			await Task.Delay(reloadTime);
			weapon.ammo = weapon.maxAmmo;
			isReloading = false;
		}
	}
}

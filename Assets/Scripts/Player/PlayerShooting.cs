using System.Threading.Tasks;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	private const string TARGET_TAG = "Target";

	[SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;
	[SerializeField] PistolAnimation pistolAnimation;


    public PlayerWeapon Weapon;

	public ParticleSystem MuzzleFlash;
	public ParticleSystem HitEffect;

	bool isReloading;
	int reloadTime = 1000;
	

	private void OnEnable()
	{
        InputManager.OnFirePressed += Shoot;
		InputManager.OnReloadButtonPressed += Reload;
	}
	private void OnDisable()
	{
		InputManager.OnFirePressed -= Shoot;
		InputManager.OnReloadButtonPressed -= Reload;
	}

	void Shoot()
    {
        if (Weapon.Ammo <= 0)
        {
            Reload();
            return;
        }
        else
        {
			Weapon.Ammo--;
			MuzzleFlash.Play();
			pistolAnimation.PlayShotAnimation();

			Debug.Log("Remaining Bullets " + Weapon.Ammo);
			

			RaycastHit hit;

			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Weapon.EffectiveRange, layerMask))
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
		Instantiate(HitEffect, point, Quaternion.LookRotation(normal));
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
			pistolAnimation.PlayReloadAnimation();
			await Task.Delay(reloadTime);
			Weapon.Ammo = Weapon.MaxAmmo;
			isReloading = false;
		}
	}
}

using System.Threading.Tasks;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public PlayerWeapon Weapon;
	public ParticleSystem MuzzleFlash;
	public ParticleSystem HitEffect;

	[SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;
	[SerializeField] PistolAnimation pistolAnimation;

	bool isReloading;
	int reloadTime = 1000;

	const string TARGET_TAG = "Target";

	void OnEnable()
	{
        InputManager.OnFirePressed += Shoot;
		InputManager.OnReloadButtonPressed += Reload;
	}
	void OnDisable()
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
			PlayShotEffects();
			DetectHit();
		}
    }

	void PlayHitEffect(Vector3 point, Vector3 normal)
	{
		Instantiate(HitEffect, point, Quaternion.LookRotation(normal));
	}
	void PlayShotEffects()
	{
		MuzzleFlash.Play();
		pistolAnimation.PlayShotAnimation();
	}

	async void Reload()
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

	void DetectHit()
	{
		RaycastHit hit;

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Weapon.EffectiveRange, layerMask))
		{
			if (hit.collider.tag == TARGET_TAG)
			{
				var targetHealth = hit.collider.gameObject.GetComponent<Health>();
				targetHealth.TakeDamage(Weapon.Damage);
			}

			PlayHitEffect(hit.point, hit.normal);
		}
	}
}

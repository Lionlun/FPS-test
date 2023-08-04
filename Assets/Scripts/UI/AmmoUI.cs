using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] PlayerShooting playerShooting;
    PlayerWeapon weapon;
    TextMeshProUGUI ammoText;

    void Start()
    {
		weapon = playerShooting.Weapon;
		ammoText = GetComponent<TextMeshProUGUI>();
	}

    void Update()
    {
		ammoText.text = $"Ammo: {weapon.Ammo} / {weapon.MaxAmmo}";
    }
}

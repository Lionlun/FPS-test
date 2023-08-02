
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] PlayerShooting playerShooting;
    PlayerWeapon playerWeapon;
    TextMeshProUGUI ammoText;

    void Start()
    {
        playerWeapon = playerShooting.Weapon;
        ammoText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
		ammoText.text = $"Ammo: {playerWeapon.Ammo} / {playerWeapon.MaxAmmo}";
    }
}

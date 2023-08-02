using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public string name = "Pistol";
    public int damage = 1;
    public float effectiveRange = 100f;
    public int maxAmmo = 10;
    [HideInInspector] public int ammo;

    public PlayerWeapon()
    {
        ammo = maxAmmo;
    }
}

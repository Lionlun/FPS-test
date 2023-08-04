using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{
    public string Name = "Pistol";
    public int Damage = 1;
    public float EffectiveRange = 100f;
    public int MaxAmmo = 7;
    [HideInInspector] public int Ammo;

    public PlayerWeapon()
    {
        Ammo = MaxAmmo;
    }
}

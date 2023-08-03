
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Crosshair crosshair;
    Vector3 camDefaultPosition;
    Vector3 camADSPosition = new Vector3 (-0.001f, 0.095f, -0.5f);
    public bool IsAiming;

    public Transform SightTarget;
    public float SightOffset;
    public float AimingInTime;
    private Vector3 weaponSwayPosition;
    private Vector3 weaponSwayPositionVelocity;
    [SerializeField] GameObject weapon;


	private void OnEnable()
	{
        InputManager.OnFire2Pressed += StartAiming;
		InputManager.OnFire2Released += StopAiming;
	}
	private void OnDisable()
	{
		InputManager.OnFire2Pressed -= StartAiming;
		InputManager.OnFire2Released -= StopAiming;
	}

    void Start()
    {
		camDefaultPosition = cam.transform.localPosition;

	}

	private void StartAiming()
    {
        Debug.Log("IsAimimng");
        IsAiming = true;
    }
   
    private void StopAiming()
    {
		IsAiming = false;
		crosshair.Activate();
	}

    private void CalculateAimingStart()
    {
		if (IsAiming)
        {
			crosshair.Deactivate();
			cam.transform.localPosition = camADSPosition;
		}
        else
        {
            cam.transform.localPosition = camDefaultPosition;
        }
	}


    void Update()
    {
		CalculateAimingStart();
	}
}

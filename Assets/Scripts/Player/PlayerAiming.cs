
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
	[SerializeField] Transform cam;
    [SerializeField] Crosshair crosshair;
    Vector3 camDefaultPosition;
    Vector3 camADSPosition = new Vector3 (0.239f, -0.0256f, 0.04f);

	private bool isAiming;

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
	void Update()
	{
		SetCameraADSPosition();
	}

	private void StartAiming()
    {
        isAiming = true;
    }
   
    private void StopAiming()
    {
		isAiming = false;
		crosshair.Activate();
	}

    private void SetCameraADSPosition()
    {
		if (isAiming)
        {
			crosshair.Deactivate();
			cam.transform.localPosition = camADSPosition;
		}
        else
        {
            cam.transform.localPosition = camDefaultPosition;
        }
	}
}

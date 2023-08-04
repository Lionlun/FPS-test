using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnFirePressed;
	public static event Action OnFire2Pressed;
    public static event Action OnFire2Released;
	public static event Action OnJumpButtonPressed;
	public static event Action OnReloadButtonPressed;
    public static event Action OnSprintButtonPressed;
	public static event Action OnSprintButtonReleased;
    public static event Action OnCrouchButtonPressed;
    public static event Action OnLayButtonPressed;

	void Update()
    {
        SendLMBPressed();
        SendJumpPressed();
        SendReloadPressed();
        SendFire2Preessed();
        SendFire2Released();
        SendSprintPressed();
        SendSprintReleased();
        SendCrouchPressed();
        SendLayPressed();

	}

    void SendLMBPressed()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            OnFirePressed?.Invoke();
        }
	}

    void SendJumpPressed()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnJumpButtonPressed?.Invoke();
        }
    }

    void SendReloadPressed()
    {
		if (Input.GetKeyDown(KeyCode.R))
		{
			OnReloadButtonPressed?.Invoke();
		}
	}

    void SendFire2Preessed()
    {
		if (Input.GetButtonDown("Fire2"))
		{
			OnFire2Pressed?.Invoke();
		}
	}

    void SendFire2Released()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            OnFire2Released?.Invoke();
        }
    }

    void SendSprintPressed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnSprintButtonPressed?.Invoke();
		}
	}

    void SendSprintReleased()
    {
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			OnSprintButtonReleased?.Invoke();
		}
	}
    void SendCrouchPressed()
    {
		if (Input.GetKeyDown(KeyCode.C))
		{
			OnCrouchButtonPressed?.Invoke();
		}
	}
    void SendLayPressed()
    {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			OnLayButtonPressed?.Invoke();
		}
	}
}

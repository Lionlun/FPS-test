using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnFirePressed;
	public static event Action OnFire2Pressed;
    public static event Action OnFire2Released;
	public static event Action OnJumpButtonPressed;
	public static event Action OnReloadButtonPressed;

	void Update()
    {
        SendLMBPressed();
        SendJumpPressed();
        SendReloadPressed();
        SendFire2Preessed();
        SendFire2Released();
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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnFirePressed;
    public static event Action OnJumpButtonPressed;
	public static event Action OnReloadButtonPressed;

	void Update()
    {
        SendLMBPressed();
        SendJumpPressed();
        SendReloadPressed();
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
}

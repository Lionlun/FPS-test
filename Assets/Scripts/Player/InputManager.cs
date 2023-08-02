using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnLMBPressed;

    void Update()
    {
        SetLMBPressed();
	}

    void SetLMBPressed()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            OnLMBPressed?.Invoke();
        }
	}
}

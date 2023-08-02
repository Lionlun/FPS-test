using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAnimation : MonoBehaviour
{
	private Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void PlayShotAnimation()
	{
		animator.SetTrigger("OnFire");
	}
}

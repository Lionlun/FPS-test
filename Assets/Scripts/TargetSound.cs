using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TargetSound : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField] private AudioClip shotSound;

	void Start()
    {
		audioSource = GetComponent<AudioSource>();
	}
	public void PlayShotSound()
	{
		audioSource.clip = shotSound;
		audioSource.Play();
	}
}

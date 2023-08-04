using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PistolSound : MonoBehaviour
{
    [SerializeField] AudioClip shot;
	[SerializeField] AudioClip reload;
	AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	public void PlayShot()
    {
		source.clip = shot;
		source.Play();
	}

	public void PlayReload()
	{
		source.clip = reload;
		source.Play();
	}
}

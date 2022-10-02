using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource gunFire;

	public void PlayGunFire(AudioClip audioClip)
	{
		if(!gunFire.isPlaying)
			gunFire.PlayOneShot(audioClip);
	}
}

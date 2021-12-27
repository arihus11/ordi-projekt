using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackSoundManagerScript : MonoBehaviour
{
    public static AudioClip jetpack;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

        jetpack = Resources.Load<AudioClip> ("jetpack");
		audioSrc = GetComponent<AudioSource> ();

	}
		

	// Update is called once per frame
	void Update () {

	}

	public static void PlayJetpackSound()
	{
        audioSrc.PlayOneShot(jetpack);
    }

	public static void StopJetpackSound()
    {
		audioSrc.Stop();
    }	
}

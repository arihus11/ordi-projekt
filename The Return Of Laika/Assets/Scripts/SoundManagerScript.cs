using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip button_switch, button_press, gameover, start, damage, jetpack, grab, correct_drop, alert_meteor_shower, life_up;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

        button_press = Resources.Load<AudioClip> ("button_press");
        button_switch = Resources.Load<AudioClip> ("button_switch");
		gameover = Resources.Load<AudioClip> ("gameover");
        start = Resources.Load<AudioClip> ("start");
        damage = Resources.Load<AudioClip> ("damage");
        jetpack = Resources.Load<AudioClip> ("jetpack");
        grab = Resources.Load<AudioClip> ("grab");
        correct_drop = Resources.Load<AudioClip> ("correct_drop");
        alert_meteor_shower = Resources.Load<AudioClip> ("alert_meteor_shower");
        life_up = Resources.Load<AudioClip> ("life_up");

		audioSrc = GetComponent<AudioSource> ();

	}
		

	// Update is called once per frame
	void Update () {

	}

	public static void PlaySound(string clip)
	{
		switch (clip) 
		{
		case "button_press":
			audioSrc.PlayOneShot (button_press);
			break;
		case "button_switch":
			audioSrc.PlayOneShot (button_switch);
			break;
		case "gameover":
			audioSrc.PlayOneShot (gameover);
			break;
		case "start":
			audioSrc.PlayOneShot (start);
			break;
		case "damage":
			audioSrc.PlayOneShot (damage);
			break;
		case "jetpack":
			audioSrc.PlayOneShot (jetpack);
			break;
		case "grab":
			audioSrc.PlayOneShot (grab);
			break;
		case "correct_drop":
			audioSrc.PlayOneShot (correct_drop);
			break;
		case "alert_meteor_shower":
			audioSrc.PlayOneShot (alert_meteor_shower);
			break;
		case "life_up":
			audioSrc.PlayOneShot (life_up);
			break;
		}
	}
    
}

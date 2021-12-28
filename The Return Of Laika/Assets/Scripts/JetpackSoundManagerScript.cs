using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackSoundManagerScript : MonoBehaviour
{
    public static AudioClip jetpack;
    static AudioSource audioSrcJet;

    // Use this for initialization
    void Start()
    {

        jetpack = Resources.Load<AudioClip>("jetpack");
        audioSrcJet = this.gameObject.GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayJetpackSound()
    {
        audioSrcJet.PlayOneShot(jetpack);
    }

    public static void StopJetpackSound()
    {
        audioSrcJet.Stop();
    }
}

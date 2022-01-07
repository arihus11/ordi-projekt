using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayExitSound : MonoBehaviour
{
    public Button newGameButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitSoundPlay()
    {
        newGameButton.Select();
        SoundManagerScript.PlaySound("button_switch");
    }
}

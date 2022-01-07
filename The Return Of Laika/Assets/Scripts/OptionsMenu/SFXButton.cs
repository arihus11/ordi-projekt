using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SFXButton : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelect(BaseEventData selected)
    {
        OptionMenuButtonsControler.selectedButtonOptions = "SFX";
        SoundManagerScript.PlaySound("button_switch");

    }
}

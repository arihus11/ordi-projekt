using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitOptionsButton : MonoBehaviour, ISelectHandler
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
        OptionMenuButtonsControler.selectedOneOptions = this.gameObject.GetComponent<Button>();
        if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            OptionMenuButtonsControler.selectedButtonOptions = "ExitOptions";
            SoundManagerScript.PlaySound("button_switch");
        }

    }
}

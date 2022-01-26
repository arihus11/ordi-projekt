using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MuiscButton : MonoBehaviour, ISelectHandler
{
    private int counter = 0;
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
        OptionMenuButtonsControler.selectedButtonOptions = "Music";
        if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            if (counter == 0)
            {
                counter = 1;
            }
            else
            {
                SoundManagerScript.PlaySound("button_switch");
            }
        }
    }
}

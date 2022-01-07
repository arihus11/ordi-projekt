using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoSellect : MonoBehaviour
{
    public Button continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.Select();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxScript2 : MonoBehaviour
{

    public GameObject[] textss;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        textss[0].SetActive(true);
        textss[1].SetActive(false);
        textss[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 3)
        {
            if (i == 0)
            {
                Invoke("enableSecondttText", 3.8f);
            }
            else
            {
                if (!(textss[i - 1].activeInHierarchy))
                {
                    textss[i].SetActive(true);
                    i++;
                }
            }
        }

    }

    public void enableSecondttText()
    {
        textss[1].SetActive(true);
        i = 1;
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxMain : MonoBehaviour
{
    private int i;
    public GameObject[] texts;
    public float enableSecondTextTime;
    private bool activatedFirst;
    // Start is called before the first frame update
    void Start()
    {
        activatedFirst = false;
        Invoke("enableFirstText", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (i < texts.Length)
        {
            if (activatedFirst == true)
            {
                if (i == 0)
                {
                    Invoke("enableSecondtText", enableSecondTextTime);
                }
                else if (i == 1 && texts.Length > 2)
                {
                    Invoke("enableThirdText", enableSecondTextTime);
                }
                else
                {
                    if (!(texts[i - 1].activeInHierarchy))
                    {
                        if (texts[i] != null)
                        {
                            texts[i].SetActive(true);
                            i++;
                        }
                    }
                }
            }
        }
    }

    public void enableFirstText()
    {
        activatedFirst = true;
        texts[0].SetActive(true);
        i = 0;
    }

    public void enableSecondtText()
    {
        if (texts[1] != null)
        {
            texts[1].SetActive(true);
            i++;
        }

    }

    public void enableThirdText()
    {
        if (texts[2] != null)
        {
            texts[2].SetActive(true);
            i++;
        }

    }
}

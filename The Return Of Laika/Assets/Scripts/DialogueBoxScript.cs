using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxScript : MonoBehaviour
{
    private int i;
    public GameObject[] texts;
    private bool activatedFirst;
    // Start is called before the first frame update
    void Start()
    {
        activatedFirst = false;
        for (int j = 0; j < texts.Length; j++)
        {
            texts[j].SetActive(false);
        }
        Invoke("enableFirstText", 16f);
    }

    // Update is called once per frame
    void Update()
    {
        if (i < 18)
        {
            if (activatedFirst == true)
            {
                if (i == 0)
                {
                    Invoke("enableSecondtText", 3f);
                }
                else
                {
                    if (!(texts[i - 1].activeInHierarchy))
                    {
                        texts[i].SetActive(true);
                        i++;
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
        texts[1].SetActive(true);
        i = 1;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
    private bool oneType;

    [TextArea(3, 10)]
    [SerializeField] string textToWrite = "";
    Text txt;
    int index = 0;
    string colorTag = "<color=#00000000>";
    private bool letterWait;

    // Use this for initialization
    void Start()
    {
        letterWait = false;
        txt = GetComponent<Text>();
        txt.text = "";
        //     StartCoroutine(WriteText());
    }

    /*  IEnumerator WriteText()
      {
          while (index <= textToWrite.Length)
          {


              txt.text = textToWrite.Substring(0, index) + colorTag + textToWrite.Substring(index) + "</color>";
              if (oneType == false)
              {
                  SoundManagerScript.PlaySound("typing");
                  oneType = true;
                  Invoke("enableType", 0.15f);
              }
              index++;
              yield return new WaitForSeconds(0.045f);


          }
          Invoke("laterDelete", 2.2f);
      } */

    public void switchLetter()
    {
        letterWait = false;
    }

    void Update()
    {


        if (index <= textToWrite.Length)
        {
            if (!letterWait)
            {
                letterWait = true;
                txt.text = textToWrite.Substring(0, index) + colorTag + textToWrite.Substring(index) + "</color>";
                if (oneType == false)
                {
                    SoundManagerScript.PlaySound("typing");
                    oneType = true;
                    Invoke("enableType", 0.15f);
                }
                index++;
                Invoke("switchLetter", 0.045f);
            }

        }
        else
        {
            Invoke("laterDelete", 2.2f);
        }
    }


    public void laterDelete()
    {
        this.gameObject.SetActive(false);
    }
    public void enableType()
    {
        oneType = false;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterMain : MonoBehaviour
{
    private bool oneType;
    [TextArea(3, 10)]
    [SerializeField] string textToWrite = "";
    Text txt;
    public float deleteLineTime;
    int index = 0;
    string colorTag = "<color=#00000000>";

    // Use this for initialization
    void Start()
    {
        oneType = false;
        txt = GetComponent<Text>();
        txt.text = "";
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
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
            yield return new WaitForSeconds(0.035f);
        }
        Invoke("laterDelete", deleteLineTime);
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

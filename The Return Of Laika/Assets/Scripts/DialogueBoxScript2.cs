using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxScript2 : MonoBehaviour
{

    public GameObject[] textss;

    // Start is called before the first frame update
    void Start()
    {
        textss[0].SetActive(true);
        textss[1].SetActive(false);
        textss[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((!(textss[0].activeInHierarchy)) && !(textss[2].activeInHierarchy))
        {
            textss[1].SetActive(true);
        }
        else if ((!(textss[1].activeInHierarchy)) && !(textss[0].activeInHierarchy))
        {
            textss[2].SetActive(true);
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter1TextControler : MonoBehaviour
{
    public GameObject endPanel;
    public float finishAtTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("closePanel", finishAtTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeScenes()
    {
        SceneManager.LoadScene("Main");
    }

    public void closePanel()
    {
        endPanel.gameObject.GetComponent<Animator>().Play("EndGamePanel");
        Invoke("changeScenes", 2f);
    }
}

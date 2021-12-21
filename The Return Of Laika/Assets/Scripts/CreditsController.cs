using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
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
        SceneManager.LoadScene("Menu");
    }

    public void closePanel()
    {
        this.gameObject.GetComponent<Animator>().Play("CreditsPanelClose");
        Invoke("changeScenes", 3f);
    }
}

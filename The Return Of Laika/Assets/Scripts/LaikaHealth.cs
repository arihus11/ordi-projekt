using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaikaHealth : MonoBehaviour
{
    public int health = 5;
    private bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Glow")
        {
            if (isWaiting == false)
            {
                health--;
                Debug.Log(health.ToString());
                StartCoroutine(DamageForTwoSeconds());
            }
        }
    }

    IEnumerator DamageForTwoSeconds()
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(2);
        isWaiting = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCollisionWarning : MonoBehaviour
{
    public GameObject warningMessageObject;
    public string warningTag = "boundary";
    
    private Animator warningAnimator;

    void Start()
    {
        if (warningMessageObject == null)
        {
            Debug.LogError("Missing warning object to display!");
        }
        else
        {
            warningAnimator = warningMessageObject.GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == warningTag)
        {
            warningAnimator.Play("Base Layer.Animate", -1, 0f);
        }
    }
}

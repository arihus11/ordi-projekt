using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTransform : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        initialPosition = this.gameObject.transform.position;
        initialRotation = this.gameObject.transform.rotation;
        initialScale = this.gameObject.transform.localScale;
    }

    public void resetToInitialTransform()
    {
        this.gameObject.transform.position = initialPosition;
        this.gameObject.transform.rotation = initialRotation;
        this.gameObject.transform.localScale = initialScale;
    }
}

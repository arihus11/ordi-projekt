using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class DisplayHint : MonoBehaviour
{
    protected enum AnimationType
    {
        display,
        hide
    }

    public GameObject messageContainer;

    protected Animator animator;
    public int baseLayerIndex = 0;
    public string baseLayerName = "Base Layer";
    public string displayAnimationName = "Display";
    public string hideAnimationName = "Hide";
    protected bool hasAnimationDisplay;
    protected bool hasAnimationHide;

    public CollisionMessageObjectTag[] collisionTagEnums;

    void Start()
    {
        animator = messageContainer.GetComponent<Animator>();
        hasAnimationDisplay = animator.HasState(baseLayerIndex, Animator.StringToHash($"{baseLayerName}.{displayAnimationName}"));
        hasAnimationHide = animator.HasState(baseLayerIndex, Animator.StringToHash($"{baseLayerName}.{hideAnimationName}"));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        onEvent(other.gameObject, AnimationType.display);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onEvent(other.gameObject, AnimationType.display);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        onEvent(other.gameObject, AnimationType.hide);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onEvent(other.gameObject, AnimationType.hide);
    }

    protected virtual void onEvent(GameObject other, AnimationType type)
    {
        if (!isCollisionTag(other.tag)) return;

        playAnimation(type);
    }

    protected bool isCollisionTag(string gameObjectTag)
    {
        foreach (var colTag in collisionTagEnums)
        {
            if (gameObjectTag == colTag.ToString())
            {
                return true;
            }
        }
        return false;
    }

    protected void playAnimation(AnimationType type)
    {
        switch (type)
        {
            case AnimationType.display:
                if (hasAnimationDisplay)
                {
                    animator.Play($"{baseLayerName}.{displayAnimationName}", -1, 0f);
                }
                break;

            case AnimationType.hide:
                if (hasAnimationHide)
                {
                    animator.Play($"{baseLayerName}.{hideAnimationName}", -1, 0f);
                }
                break;
        }
    }
}

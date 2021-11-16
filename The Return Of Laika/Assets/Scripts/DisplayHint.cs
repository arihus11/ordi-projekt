using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class DisplayHint : MonoBehaviour
{
    private enum AnimationType
    {
        display,
        hide
    }

    public GameObject messageContainer;

    private Animator animator;
    public int baseLayerIndex = 0;
    public string baseLayerName = "Base Layer";
    public string displayAnimationName = "Display";
    public string hideAnimationName = "Hide";
    private bool hasAnimationDisplay;
    private bool hasAnimationHide;

    public CollisionMessageObjectTag collisionTagEnum;

    void Start()
    {
        animator = messageContainer.GetComponent<Animator>();
        hasAnimationDisplay = animator.HasState(baseLayerIndex, Animator.StringToHash($"{baseLayerName}.{displayAnimationName}"));
        hasAnimationHide = animator.HasState(baseLayerIndex, Animator.StringToHash($"{baseLayerName}.{hideAnimationName}"));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        onEvent(other.gameObject.tag, AnimationType.display);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onEvent(other.gameObject.tag, AnimationType.display);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        onEvent(other.gameObject.tag, AnimationType.hide);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onEvent(other.gameObject.tag, AnimationType.hide);
    }

    private void onEvent(string gameObjectTag, AnimationType type)
    {
        if (!isCollisionTag(gameObjectTag)) return;

        playAnimation(type);
    }

    private bool isCollisionTag(string gameObjectTag)
    {
        return gameObjectTag == collisionTagEnum.ToString();
    }

    private void playAnimation(AnimationType type)
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

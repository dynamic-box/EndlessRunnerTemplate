using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animation playerAnimationComponent;

    [SerializeField] private float swipeDistance;

    [SerializeField] private AnimationArray[] playerAnimationArray;

    private Vector2 initialMousePos;

    private bool isScreenPressed = false;

    private SwipeDirection currentPlayerSwipeDirection;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(isScreenPressed==false && Input.GetMouseButtonDown(0))
        {
            isScreenPressed = true;

            initialMousePos = Input.mousePosition;
        }

        //
        if(isScreenPressed==true && Input.mousePosition.y >= initialMousePos.y + swipeDistance)
        {
            currentPlayerSwipeDirection = SwipeDirection.UP;
            Debug.Log(currentPlayerSwipeDirection);

            isScreenPressed = false;
        }
        else if(isScreenPressed == true && Input.mousePosition.y <= initialMousePos.y - swipeDistance)
        {
            currentPlayerSwipeDirection = SwipeDirection.DOWN;
            Debug.Log(currentPlayerSwipeDirection);
            isScreenPressed = false;
        }
        else if (isScreenPressed == true && Input.mousePosition.x >= initialMousePos.x + swipeDistance)
        {
            currentPlayerSwipeDirection = SwipeDirection.RIGHT;
            Debug.Log(currentPlayerSwipeDirection);
            isScreenPressed = false;
        }
        else if (isScreenPressed == true && Input.mousePosition.x <= initialMousePos.x - swipeDistance)
        {
            currentPlayerSwipeDirection = SwipeDirection.LEFT;
            Debug.Log(currentPlayerSwipeDirection);
            isScreenPressed = false;
        }
    }
}
 
[System.Serializable]
public class AnimationArray
{
    public AnimationClip[] animationClipArray;
}

public enum SwipeDirection {LEFT, RIGHT,UP, DOWN};

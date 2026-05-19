using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ONLY UPDATE TO FACE THE TARGET
        //WHEN THE MOUSE IS CLICKED:
        //bool isLeftKeyPressed = Keyboard.current.leftArrowKey.isPressed;
        bool leftMouseIsPressed = Mouse.current.leftButton.isPressed;
        bool leftMouseWasPressed = Mouse.current.leftButton.wasPressedThisFrame;
        bool leftMouseWasReleased = Mouse.current.leftButton.wasReleasedThisFrame;
        Debug.Log(leftMouseWasPressed);

        if (leftMouseWasPressed)
        {
            //Direction to B from A: B-A
            //The direction from this object towards the target
            Vector3 directionToTarget = target.position - transform.position;
            transform.up = directionToTarget;
        }
    }
}

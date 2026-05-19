using UnityEngine;
using UnityEngine.InputSystem;

public class Controler : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isUpHeld = Keyboard.current.upArrowKey.isPressed;
        if (isUpHeld)
        {
            //Vector2 currentPosition = transform.position;
            //currentPosition.y += moveSpeed * Time.deltaTime;
            //transform.position = currentPosition;
            transform.position += transform.up * moveSpeed * Time.deltaTime; //faster? better? syntax
        }

        bool isDownHeld = Keyboard.current.downArrowKey.isPressed;
        if (isDownHeld)
        {
            //Vector2 currentPosition = transform.position;
            //currentPosition.y -= moveSpeed * Time.deltaTime;
            //transform.position = currentPosition;
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
        }
        //use transform.forward for z axis
        bool isLeftHeld = Keyboard.current.leftArrowKey.isPressed;
        if (isLeftHeld)
        {
            transform.eulerAngles += transform.forward * moveSpeed * Time.deltaTime;
        }

    }
}

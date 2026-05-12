using UnityEngine;
using UnityEngine.InputSystem;

public class Hider : MonoBehaviour
{
    public Vector3 hidePosition;
    public float hideDistance;
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();

        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        float distance = Vector3.Distance(worldMousePosition, transform.position);

        Debug.Log(distance);

        //ENTER THIS CODE:
        //If the mouse is close to this obj
        if (distance < hideDistance) 
        {
            transform.position = hidePosition;
        }
    }
}

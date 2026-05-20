using UnityEngine;
using UnityEngine.InputSystem;

public class Assignment1_Traffic : MonoBehaviour
{
    public float speed;
    public float duration;
    float progress = 0f;
    public float resetPos;
    public float mouseDistance;
    public Camera gameCamera;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.y += speed * Time.deltaTime;
        transform.position = currentPosition;

        progress += Time.deltaTime;

       

        if(currentPosition.y > resetPos)
        {
            currentPosition.y = -6.94f;
        }

        transform.position = currentPosition;

        Vector2 currentMousePosition = Mouse.current.position.ReadValue();
       
        Vector2 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
       // Debug.Log(worldMousePosition);
        float distance = Vector2.Distance(currentPosition, worldMousePosition);
     
        Debug.Log(distance);

        if (distance < mouseDistance)
        {
           Debug.Log("Near");
        }
    }
}

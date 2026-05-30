using UnityEngine;
using UnityEngine.InputSystem;

public class Assignment1_Traffic : MonoBehaviour
{
    public float MaxSpeed;
    public float speed;
    public float MinSpeed;
    public float lerpSpeed;
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
        currentPosition.y += MaxSpeed * Time.deltaTime;
        transform.position = currentPosition;

        progress += Time.deltaTime;

      

        Vector2 currentMousePosition = Mouse.current.position.ReadValue();
      

        Vector2 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
       // Debug.Log(worldMousePosition);
        float distance = Vector2.Distance(currentPosition, worldMousePosition);


        if (distance < mouseDistance)
        {
            //speed = 0f;
            speed = Mathf.Lerp(MaxSpeed, MinSpeed, lerpSpeed * Time.deltaTime);
            Debug.Log("Near");
        }
        else
        {
            speed = Mathf.Lerp(speed, MaxSpeed, lerpSpeed * Time.deltaTime);
        }

        if (currentPosition.y > resetPos)
        {
            currentPosition.y = -6.94f;
        }

        transform.position = currentPosition;
    }
}

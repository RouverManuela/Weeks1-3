using UnityEngine;
using UnityEngine.InputSystem;

public class Assignment1_Traffic : MonoBehaviour
{
    //Speed and movement
    public float MaxSpeed;
    public float MinSpeed;
    public float lerpSpeed;
    public float resetPos;
    public float mouseDistance;
    public Camera gameCamera;
    float speed;

    //Shaking animation
    public AnimationCurve engine;
    public float minShake;
    public float maxShake;
    float progress = 0f;
    public float duration;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 currentPosition = transform.position;
        currentPosition.y += speed * Time.deltaTime;
        transform.position = currentPosition;

        Vector2 currentMousePosition = Mouse.current.position.ReadValue();

        Vector2 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
       // Debug.Log(worldMousePosition);
        float distance = Vector2.Distance(currentPosition, worldMousePosition);


        if (distance < mouseDistance)
        {
            //speed = 0f;
            speed = Mathf.Lerp(speed, MinSpeed, lerpSpeed * Time.deltaTime);
           
        }
        else
        {
            speed = Mathf.Lerp(speed, MaxSpeed, lerpSpeed * Time.deltaTime);
        }

        if (currentPosition.y > resetPos)
        {
            currentPosition.y = -6.94f;
            Debug.Log("jump");
        }

        progress += Time.deltaTime;

        if (progress > duration)
        {
            progress = 0f;
        }
        currentPosition.x = minShake + engine.Evaluate(progress / duration) * maxShake;




        transform.position = currentPosition;
    }
}

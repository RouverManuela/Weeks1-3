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
       //Changung the car's current position 
        Vector2 currentPosition = transform.position;
        currentPosition.y += speed * Time.deltaTime;
        transform.position = currentPosition;

        //Getting and converting the mouse's position into world space (in order to allow the game to detect it)
        Vector2 currentMousePosition = Mouse.current.position.ReadValue();
        Vector2 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
       //checks mouse's distance from object
        float distance = Vector2.Distance(currentPosition, worldMousePosition);

        //If the mouse is near the car it slows it down till it stops Speed= maxSpeed----lerpSpeed----minSpeed(0)
        if (distance < mouseDistance)
        {
            //speed = 0f;
            speed = Mathf.Lerp(speed, MinSpeed, lerpSpeed * Time.deltaTime);
           
        }
        //otherwise, cars keep going
        else
        {
            speed = Mathf.Lerp(speed, MaxSpeed, lerpSpeed * Time.deltaTime);
        }
        //Once the car exits the camera view they reset and teleport down
        if (currentPosition.y > resetPos)
        {
            //lower than camera to give the impression of time passing 
            currentPosition.y = -6.94f;
            Debug.Log("jump");
        }
        //Animation curve progress
        progress += Time.deltaTime;

        //Lets car shake side to side 
        if (progress > duration)
        {
            progress = 0f;
        }
        currentPosition.x = minShake + engine.Evaluate(progress / duration) * maxShake;

        transform.position = currentPosition;
    }
}

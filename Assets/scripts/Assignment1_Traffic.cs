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

////////////////////////////////////////////////////////Inspector Values//////////////////////////////////////////////////////////////////////
// Blue Car- MaxSpeed(3), MinSpeed(0), LerpSpeed(1.5), ResetPos(6.94), MouseDistance(2.5), MinShake(-0.81), MaxSpeed(-0.82), Duration(1)  ////
// Red Car- MaxSpeed(4.5), MinSpeed(0), LerpSpeed(2), RestePos(7), MouseDistance(2.5), MinShake(0.32), MaxSpeed(0.33), Duration(1)  /////////
// Orange Car- MaxSpeed(4.5), MinSpeed(0), LerpSpeed(2), RestePos(7), MouseDistance(2.5), MinShake(1.2), MaxSpeed(1.21), Duration(1)  ///////
// Green Car- MaxSpeed(3.5), MinSpeed(0), LerpSpeed(2), RestePos(6.56), MouseDistance(-2.17), MinShake(-2.18), MaxSpeed(0.33), Duration(1)///




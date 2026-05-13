using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CodingGym1 : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public Camera cameraa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x += speedX * Time.deltaTime;
        newPosition.y += speedY * Time.deltaTime;
        
        Vector2 screenPosition = cameraa.WorldToScreenPoint(newPosition);

        if (screenPosition.x > Screen.width)
        {
            speedX *= -1f;
            Debug.Log(newPosition);
        }
        if (screenPosition.x < Screen.width - Screen.width)
        {
            speedX *= -1f;
        }
        if(screenPosition.y > Screen.height)
        { 
            speedY *= -1f;
        }
        if (screenPosition.y < Screen.height - Screen.height)
        {
            speedY *= -1f;
        }
       transform.position = newPosition;

    }
}

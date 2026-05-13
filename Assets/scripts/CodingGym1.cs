using UnityEngine;

public class CodingGym1 : MonoBehaviour
{
    public float speed;
     public float Max;
    public float Min;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += speed;
        newPosition.y += speed;

        transform.position = newPosition;


        if (newPosition > Max)
        {

            speed *= -1f;

        }

        if (newPosition.x < Min)
        {
            speed *= -1f;

        }

        if (newPosition.y > Max)
        {

            speed *= -1f;

        }

        if (newPosition.y < Min)
        {
            speed *= -1f;

        }

    }
}

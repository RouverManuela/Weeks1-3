using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float zMax;
    public float Rspeed;
    public float zMin;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z += Rspeed * Time.deltaTime;
        transform.eulerAngles = currentRotation;
       

       if (currentRotation.z > zMax)
        {
            Rspeed = -Rspeed;
            //Debug.Log("Crossing the upper threshold currentZ[" + currentRotation.z.ToString() + "] zMax[" + zMax.ToString() + "]");
        }
       if (currentRotation.z < zMin)
        {
            Rspeed = -Rspeed;
            //Debug.Log("Crossing the lower threshold");
        }
        
    }
}

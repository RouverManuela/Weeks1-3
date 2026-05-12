using UnityEngine;

public class Guard : MonoBehaviour
{
    public Vector3 startValue;
    public Vector3 endValue;
    public Vector3 currentValue;
    public float duration;
     float progress = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;

        //NUMBERS:
        //float number = Mathf.Lerp(startValue, endValue, progress / duration);

        //POSITIONS:
        currentValue = Vector3.Lerp(startValue, endValue, progress / duration);

        transform.position = currentValue;

        //currentValue == endValue
        //gpood to check bugs to see output of values in console
        Debug.Log("progress: " + progress + " duration: " + duration);
        if (progress > duration)
        {
            Debug.Log("progress is equal to duration");
            progress = 0f;
        }
    }
}

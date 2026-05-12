using UnityEngine;

public class ChangePosTimer : MonoBehaviour
{
    float duration = 3f;
    float progress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (progress > duration)
        {
            Debug.Log("end timer");
            transform.position = Random.insideUnitCircle * 5;
            progress = 0f;
        }
    }
}

using UnityEngine;

public class Pulser : MonoBehaviour
{
    public AnimationCurve curve;

    public float startSize;
    public float endSize;
    float progress = 0f;
    public float duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        transform.localScale = curve.Evaluate(progress / duration) * Vector3.one;
    }
}

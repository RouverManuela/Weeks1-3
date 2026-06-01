using UnityEngine;
using UnityEngine.InputSystem;

//**Referenced from "Chaser" as taught in class**
//Sprite from: https://stock.adobe.com/ca/search?k=stop+sign+png+&search_type=usertyped&filters%5Bgentech%5D=exclude&asset_id=221525069
public class StopSign_Cursor : MonoBehaviour
{
    public Camera gameCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();

        //gets mouse psotion on screen
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0f;
        transform.position = worldMousePosition;
    }
}

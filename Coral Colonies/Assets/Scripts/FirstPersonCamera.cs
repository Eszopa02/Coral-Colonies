using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    // Followed video: "First Person Camera in Unity" (https://www.youtube.com/watch?v=5Rq8A4H6Nzw) by Unity Ace

    //Variables
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    bool lockedCursor = true;


    // Start is called before the first frame update
    void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Collect Mouse Input

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y")*mouseSensitivity;

        //Rotate the Camera around its local X axis

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -12f, 50f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //Rotate the Player Object and the Camera around its Y axis

        player.Rotate(Vector3.up * inputX);
    }
}

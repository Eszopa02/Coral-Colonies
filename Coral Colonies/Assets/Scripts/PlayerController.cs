using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Reference the transform
    Transform t;

    [Header("Player Rotation")]
    public float sensitivity = 1f;

    //Mouse input variables
    float rotationX;
    float rotationY;

    [Header("Player Movement")]
    public float speed = 1f;
    float moveX;
    float moveY;
    float moveZ;

    // Start is called before the first frame update
    void Start()
    {
        t = this.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        LookAround();

        //Debug function to unlock cursor
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void LookAround()
    {
        //Get the mouse input
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;

        //Setting the rotation value every update
        t.localRotation = Quaternion.Euler(-rotationY, rotationX, 0);

    }

    void Move()
    {
        //Get the movement input
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        moveZ = Input.GetAxis("Forward");

        //Move the Character (Swimming ver)
        t.Translate(new Vector3(moveX, 0, moveZ) * Time.deltaTime * speed);
        t.Translate(new Vector3(0, moveY, 0) * Time.deltaTime * speed, Space.World);
    }
}

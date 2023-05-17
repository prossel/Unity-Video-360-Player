using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraControlKeyboard : MonoBehaviour
{

    public KeyCode lookUp = KeyCode.UpArrow;
    public KeyCode lookDown = KeyCode.DownArrow;
    public KeyCode lookLeft = KeyCode.LeftArrow;
    public KeyCode lookRight = KeyCode.RightArrow;
    public KeyCode zoomIn = KeyCode.I;
    public KeyCode zoomOut = KeyCode.O;

    public float speed = 1;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = speed * Time.deltaTime;

        // Rotate up down arount camera's x axis
        cam.transform.Rotate((Input.GetKey(lookUp) ? -move : 0) + (Input.GetKey(lookDown) ? move : 0), 0, 0);

        // Rotate left right around world's vertical axis
        cam.transform.Rotate(0, (Input.GetKey(lookLeft) ? -move : 0) + (Input.GetKey(lookRight) ? move : 0), 0, Space.World);

        // Zoom
        float fov = cam.fieldOfView;
        fov += (Input.GetKey(zoomIn) ? -move : 0) + (Input.GetKey(zoomOut) ? move : 0);
        cam.fieldOfView = Mathf.Clamp(fov, 0, 179);

    }
}

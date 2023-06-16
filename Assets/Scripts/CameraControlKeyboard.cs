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
    public float accel = 1;

    Vector3 vSpeed;
    Vector3 vTargetSpeed;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        vTargetSpeed.x = Input.GetAxis("Vertical") * speed;
        vTargetSpeed.y = Input.GetAxis("Horizontal") * speed;
        vTargetSpeed.z = Input.GetAxis("Zoom") * speed;

        vSpeed = vTargetSpeed * Time.deltaTime;

        // Rotate up down arount camera's x axis
        cam.transform.Rotate(-vSpeed.x, 0, 0);

        // Rotate left right around world's vertical axis
        cam.transform.Rotate(0, vSpeed.y, 0, Space.World);

        // Zoom
        float fov = cam.fieldOfView;
        fov += vSpeed.z;
        cam.fieldOfView = Mathf.Clamp(fov, 0, 179);

    }
}

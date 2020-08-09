using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;   // Main Camera reference

    [Range(1.0f, 1000.0f)]
    public float mouseSensitivity = 100.0f;  // Select sensitivity

    private float mainCameraXRotation, mainCameraYRotation;

    private const float defaultMainCameraXRotation = 45.0f, defaultMainCameraYRotation = 0.0f; // value of Main Camera X and Y Rotation on Start
    private const float cameraSpeed = 100.0f;    // Camera Empty Object const speed
    private const float margin = 10.0f;
    private const float zoom = 5.0f;

    void Start()
    {
        mainCamera.transform.rotation = Quaternion.Euler(45.0f, 0.0f, 0.0f); // Select Main Camera X Rotation on Start

        mainCameraXRotation = defaultMainCameraXRotation;
        mainCameraYRotation = defaultMainCameraYRotation;
    }

    void LateUpdate()
    {
        Vector3 CameraPos = mainCamera.transform.position;

        // Clamp camera position
        mainCamera.transform.position = new Vector3(Mathf.Clamp(CameraPos.x, -200f, 200f), Mathf.Clamp(CameraPos.y, 1f, 200f), Mathf.Clamp(CameraPos.z, -200f, 200f));
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;    // Get mouse X value
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 2.0f * Time.deltaTime;    // Get mouse Y value

        // Rotation
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.down * mouseX);    // Rotate Camera Empty Object

            mainCameraXRotation -= mouseY;
            mainCameraXRotation = Mathf.Clamp(mainCameraXRotation, 0.0f, 90.0f);    // Rotation between 0 and 90 angle

            mainCameraYRotation += mouseX;

            mainCamera.transform.localRotation = Quaternion.Euler(mainCameraXRotation, mainCameraYRotation, 0.0f); // Rotate Main Camera
        }
        else
        {
            // Movement
            if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y > Screen.height - margin)
            {
                transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);    // Forward
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x < margin)
            {
                transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);   // Left
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y < margin)
            {
                transform.Translate(Vector3.back * cameraSpeed * Time.deltaTime);   // Backward
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x > Screen.width - margin)
            {
                transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);  // Right
            }
        }

        // Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && mainCamera.fieldOfView > 30.0f)
        {
            mainCamera.fieldOfView -= zoom;
        }

        // Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && mainCamera.fieldOfView < 60.0f)
        {
            mainCamera.fieldOfView += zoom;
        }
    }
}

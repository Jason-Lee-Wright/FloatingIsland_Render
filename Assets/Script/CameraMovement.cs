using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CameraMovement : MonoBehaviour
{
    public float OrbitSpeed = 500.0f;
    public float IdleRotate = 10.0f;
    public GameObject CenterOfOrbit;

    private Vector3 SpaceOrbit;

    private void Start()
    {
        SpaceOrbit = CenterOfOrbit.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            CameraOrbit();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
            this.gameObject.transform.Rotate(0, IdleRotate * Time.deltaTime, 0);
        }
    }

    void CameraOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            float verticalInput = Input.GetAxis("Mouse Y") * OrbitSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * OrbitSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + verticalInput, transform.eulerAngles.y + horizontalInput, 0f);
        }
    }
}

using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    private Camera mainCamera;
    private bool isRotating = false;
    private Vector3 lastMousePosition;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isRotating = true;
                lastMousePosition = Input.mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0))
            isRotating = false;

        if (isRotating)
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;

            float rotationX = deltaMousePosition.y * 0.1f;

            Vector3 currentRotation = transform.localEulerAngles;
            
            currentRotation.x -= rotationX;

            transform.localEulerAngles = new Vector3(currentRotation.x, -90f, 90f);

            lastMousePosition = Input.mousePosition;
        }
    }
}

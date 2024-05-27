using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zCoordinate;
    private float fixedY; 

    void Start()
    {
        mainCamera = Camera.main;
        fixedY = transform.position.y;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                zCoordinate = mainCamera.WorldToScreenPoint(transform.position).z;
                offset = transform.position - GetMouseWorldPosition();
            }
        }
        if (Input.GetMouseButtonUp(0))
            isDragging = false;

        if (isDragging)
            transform.position = new Vector3(GetMouseWorldPosition().x + offset.x, fixedY, GetMouseWorldPosition().z + offset.z);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;

        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}

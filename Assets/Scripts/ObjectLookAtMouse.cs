using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    //[SerializeField] private float cameraAngle = 68f;
    //[SerializeField] private float maxDistance = 21f;

    private Vector3 mousePosition;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            lookAtMouse();
        }

    }

    private void lookAtMouse()
    {
        // Get the mouse position in screen space
        mousePosition = Input.mousePosition;

        // Project the mouse position onto the game world
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(distance);
            Vector3 lookPosition = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);

            // Adjust the object's rotation to look at the mouse cursor
            transform.LookAt(lookPosition);

            // Adjust the object's rotation based on the camera angle
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);

            
        }
    }
}

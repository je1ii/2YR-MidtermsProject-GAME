using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform crosshair;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    void Update()
    {
        Vector3 viewDir = crosshair.position - new Vector3(transform.position.x, crosshair.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        playerObj.forward = viewDir.normalized;
    }
}

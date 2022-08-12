using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private float xMouse, yMouse;
    private float yRotation, xRotation;
    private float sensivity = 405.5f;
    [SerializeField]
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        yMouse = -Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        yRotation += yMouse;
        xRotation += xMouse;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        playerTransform.Rotate(Vector3.up * xMouse);
    }
}
    
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float xAxis, zAxis;
    [SerializeField]
    private float movementSpeed = 205.5f;
    [SerializeField]
    private Rigidbody rb;
    private int jumpHeight = 6;
    [SerializeField]
    private bool jumpActive,onGround;

    private void Awake() => rb.GetComponent<Rigidbody>();

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            jumpActive = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 305.5f;
        }
        else
        {
            movementSpeed = 205.5f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = transform.forward * zAxis * movementSpeed * Time.deltaTime + transform.up * rb.velocity.y + transform.right * xAxis * movementSpeed * Time.deltaTime;

        if (jumpActive)
        {
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            jumpActive = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground")
        {
            onGround = false;
        }
    }

}
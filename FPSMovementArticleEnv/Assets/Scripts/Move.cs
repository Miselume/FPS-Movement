using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    private float xAxis, zAxis;
    private float moveSpeed = 405.5f;
    
    private bool jumpActive;
    private int jumpHeight = 6;
    private RaycastHit hit;

    private float dashSpeed = 100f;
    private float heightOfPlayer;

    [SerializeField]
    private Collider playerCollider;
    [SerializeField]
    private Rigidbody rb;

    void Awake() => rb = GetComponent<Rigidbody>();

    private void Start() => heightOfPlayer = transform.localScale.y;

    private void Update()
    {
		xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && onGround()) jumpActive = true;

        if (Input.GetKey(KeyCode.LeftControl)) transform.localScale = new Vector3(transform.localScale.x, heightOfPlayer / 1.5f, transform.localScale.z);
        else transform.localScale = new Vector3(transform.localScale.x, heightOfPlayer, transform.localScale.z);
    }

    void FixedUpdate()
	{
		rb.velocity = transform.forward * zAxis + transform.up * rb.velocity.y + transform.right * xAxis;

        if (jumpActive)
        {
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            jumpActive = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 dashVector = new Vector3(rb.velocity.x, 0, rb.velocity.z) * dashSpeed;
            rb.AddForce(dashVector);
        }
    }

    private bool onGround()
    {
        if(Physics.Raycast(transform.position , -transform.up , out hit , 1.45f))
        {
            if(hit.collider.tag == "Ground")
            {
                return true;
            }
        }

        return false;
    }
}

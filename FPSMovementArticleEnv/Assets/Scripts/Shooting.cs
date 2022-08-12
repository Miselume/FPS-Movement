using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private RaycastHit hit;
    private bool trigger;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform gunTransform;

    [SerializeField]
    private int ammo = 6;
    private bool hasAmmo = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 6;
        }

        trigger = Input.GetKeyDown(KeyCode.Mouse0);
        if (trigger && ammo > 0) ammo -= 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.Raycast(cameraTransform.position, transform.forward , out hit , 1000) && trigger && ammo > 0)
        {
            print("Killed!");
            Destroy(hit.collider.gameObject);
        }

        else
        {
            Debug.DrawRay(cameraTransform.position, transform.forward * 1000, Color.red);
        }

        Debug.DrawRay(cameraTransform.position, transform.forward * 1000, Color.green);
    }
}

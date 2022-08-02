using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    
    [SerializeField] float Xspeed=3.5f;
    [SerializeField] float Yspeed = 3.5f;

    [SerializeField] float eulerAngleX;
    [SerializeField] float eulerAngleY;

    [SerializeField] float moveSpeed;

    private float gravity = -9.81f;
    private Vector3 moveForce;

    private CharacterController characterControl;

    public ParticleSystem particle;
    

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        characterControl = GetComponent<CharacterController>();

        
    }

    void Update()
    {
        UpdateRotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (Input.GetButtonDown("Fire1"))
        {
            particle.Play();
        }

        MoveTo(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        if (!characterControl.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }

        characterControl.Move(moveForce * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * Yspeed;

        

        transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);
    }

    
    
}

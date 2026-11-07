using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform cameraT;
    CharacterController controller;
    float moveSpeed;
    float walkSpeed = 5f;
    float flySpeed = 11f;
    
    bool flyToggle;
    
    float gravity;
    float gravityScale = -9.8f;

    float sensitivity = 3f;

    void Start() {
        controller = GetComponent<CharacterController>();
        moveSpeed = walkSpeed;
    }

    void Update() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        UpdateMovement();
        UpdateCameraMovement();
    }

    void UpdateMovement() {
        Vector3 inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        CheckFlyToggle();
        if (flyToggle) {
            gravity = 0;
            moveSpeed = flySpeed;
            if (Input.GetKey(KeyCode.Space)) {
                gravity = 8f;
            }

            if (Input.GetKey(KeyCode.LeftShift)) {
                gravity = -8f;
            }
        }
        else {
            moveSpeed = walkSpeed;
            if (!controller.isGrounded) {
                gravity += gravityScale * Time.deltaTime;
            }
            else {
                gravity = -0.5f;
                if (Input.GetKeyDown(KeyCode.Space)) {
                    gravity = 6.5f;
                }
            }
        }
        
        Vector3 finalVelocity = ((moveDir * moveSpeed) * Time.deltaTime) + (Vector3.up * gravity * Time.deltaTime); 
        controller.Move(finalVelocity);
    }

    float mouseRotationY;
    void UpdateCameraMovement() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        transform.Rotate(Vector3.up * mouseX);
        mouseRotationY += mouseY;
        mouseRotationY = Mathf.Clamp(mouseRotationY, -90, 90);
        cameraT.localEulerAngles = new Vector3(-mouseRotationY, cameraT.localEulerAngles.y, 0);
    }

    float lastJumpTime;
    void CheckFlyToggle() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Time.time - lastJumpTime < 0.25f) {
                flyToggle = !flyToggle;
            }

            lastJumpTime = Time.time;
        }
    }
}

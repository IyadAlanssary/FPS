using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{

    [SerializeField] private float movementSpeed = 12f, jumpHeight = 3f, gravity = -9.8f, groundDistance = 0.4f;
    public CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;
    private bool isGrounded;
    private Vector3 velocity;
   
    void Update(){
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if( isGrounded && velocity.y < 0 ){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move( move * movementSpeed * Time.deltaTime);

        if( Input.GetButtonDown("Jump") && isGrounded ){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;////////    delta y = 0.5 g t^2
        characterController.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene("1");
        }
    }
}

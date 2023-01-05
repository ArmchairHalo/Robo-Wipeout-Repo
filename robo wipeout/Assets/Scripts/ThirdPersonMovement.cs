using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;


    // Update is called once per frame
    void FixedUpdate()
    {

        groundedPlayer = controller.isGrounded;
        Debug.Log("grounded player =" + groundedPlayer);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        string[] joysticks = Input.GetJoystickNames();

        for(int i = 0; i < joysticks.Length; ++i)
        {
            //Debug.Log(i+" "+joysticks[i]);
        }


        float horizontal = Input.GetAxis("HorizontalL");
        float vertical = Input.GetAxis("VerticalL");

        //Debug.Log(horizontal + ", " + vertical);

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if(direction.magnitude >= 0.1f)
        {
            direction.Normalize();
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("JUMP PRESSED!!!!!");
        }

        if (Input.GetButton("Jump") && groundedPlayer)
        {
            Debug.Log("JUMP PRESSED AND GROUNDED!!!!!!");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

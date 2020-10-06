using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public thrusterController thrusterFrontRightStar;
    public thrusterController thrusterFrontRightRetro;
    public thrusterController thrusterFrontLeftRetro;
    public thrusterController thrusterFrontLeftPort;
    public thrusterController thrusterRearLeftPort;
    public thrusterController thrusterRearLeftPro;
    public thrusterController thrusterRearRightPro;
    public thrusterController thrusterRearRightStar;

    public float RightTriggerPressed;
    public float LeftTriggerPressed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float frontRightStarThrust = 0.0f;
        float frontRightRetroThrust = 0.0f;
        float frontLeftRetroThrust = 0.0f;
        float frontLeftPortThrust = 0.0f;
        float rearLeftPortThrust = 0.0f;
        float rearLeftProThrust = 0.0f;
        float rearRightProThrust = 0.0f;
        float rearRightStarThrust = 0.0f;

        var gamepad = Gamepad.current;
        var rightTriggerPressed = gamepad.rightTrigger.ReadValue();
        this.RightTriggerPressed = rightTriggerPressed;

        rearRightStarThrust += rightTriggerPressed;
        frontLeftPortThrust += rightTriggerPressed;
        //this.thrusterRearRightStar.ApplyForce(rightTriggerPressed);

        //this.thrusterFrontLeftPort.ApplyForce(rightTriggerPressed);

        var leftTriggerPressed = gamepad.leftTrigger.ReadValue();
        this.LeftTriggerPressed = leftTriggerPressed;
        frontRightStarThrust += leftTriggerPressed;
        rearLeftPortThrust += leftTriggerPressed;

        var stickState = gamepad.rightStick.ReadValue();

        if (stickState.y >= 0)
        {
            rearLeftProThrust += stickState.y;
            rearRightProThrust += stickState.y;
        }
        if (stickState.y <= 0)
        {
            frontLeftRetroThrust -= stickState.y;
            frontRightRetroThrust -= stickState.y;

        }
        if (stickState.x >= 0)
        {
            frontLeftPortThrust += stickState.x;
            rearLeftPortThrust += stickState.x;
        }

        if (stickState.x <= 0)
        {
            frontRightStarThrust -= stickState.x;
            rearRightStarThrust -= stickState.x;
        }
        thrusterFrontRightStar.ApplyForce(frontRightStarThrust);
        thrusterFrontRightRetro.ApplyForce(frontRightRetroThrust);
        thrusterFrontLeftRetro.ApplyForce(frontLeftRetroThrust);
        thrusterFrontLeftPort.ApplyForce(frontLeftPortThrust);
        thrusterRearLeftPort.ApplyForce(rearLeftPortThrust);
        thrusterRearLeftPro.ApplyForce(rearLeftProThrust);
        thrusterRearRightPro.ApplyForce(rearRightProThrust);
        thrusterRearRightStar.ApplyForce(rearRightStarThrust);
    }
}
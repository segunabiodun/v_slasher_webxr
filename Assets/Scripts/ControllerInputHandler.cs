using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class ControllerInputHandler : MonoBehaviour
{
    private readonly string TRIGGER_BUTTON = "Trigger";
    private readonly string GRIP_BUTTON = "Grip";

    private WebXRController controller;

    void Awake()
    {
        // Retrieve the WebXRController component.
        controller = GetComponent<WebXRController>();
    }

    void Update()
    {
        // Controller hand being used.
        WebXRControllerHand hand = controller.hand;

        // GetButtonDown and GetButtonUp:
        if (controller.GetButtonDown(TRIGGER_BUTTON))
        {
            print(hand + " controller Trigger is down!");
            GameManager.instance.StartGame();
        }

        if (controller.GetButtonUp(TRIGGER_BUTTON))
            print(hand + " controller Trigger is up!");

        // GetAxis:
        if (controller.GetAxis(GRIP_BUTTON) > 0)
            print(hand + " controller Grip value: " + controller.GetAxis("Grip"));
    }
}
